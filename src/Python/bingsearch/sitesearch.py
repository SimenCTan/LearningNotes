import requests

# Define your API key and endpoint
MY_API_KEY = "27ced4a00491419080ec9e7422afba14"
WEB_SEARCH_ENDPOINT = "https://api.bing.microsoft.com/v7.0/search"

# List of websites to exclude (e.g., youtube.com, amazon.com)
LINKS_TO_EXCLUDE = ["-site:youtube.com", "-site:amazon.com"]

def bing_search(user_query):
    params = {
        "mkt": "en-US",
        "setLang": "en-US",
        "textDecorations": False,
        "textFormat": "raw",
        "responseFilter": "Webpages",
        "count": 20,
        "q": user_query + " " + " ".join(LINKS_TO_EXCLUDE)
    }

    headers = {
        "Ocp-Apim-Subscription-Key": MY_API_KEY,
        "Accept": "application/json",
        "Retry-After": "1",
    }

    print(params)
    response = requests.get(WEB_SEARCH_ENDPOINT, headers=headers, params=params, timeout=15)
    response.raise_for_status()
    search_data = response.json()
    return search_data

# Example usage
user_query = "books to read this summer"
search_results = bing_search(user_query)

# Process the search results as needed
print(search_results)
