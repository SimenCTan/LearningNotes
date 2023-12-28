# Custom Hooks
It is possible to make a custom hook on top of the available React hooks. For instance, when we fetch data we with use either fetch or axios to send an HTTP request and useEffect hooks to manage the React life cycle. Let's build useFetch custom hook on top of useEffect and useState.

We wrote this snippet of code in the previous section and we use useEffect hooks to fetch data from API. Now, let's convert this code to a custom hook. The naming convention for a custom hook is camelCase and it starts with the word use that is why we called our custom hook, useFetch.
