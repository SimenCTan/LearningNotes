# import re
# txt = 'I love to teach python and javaScript'
# match_txt = re.match('I love',txt,re.I)
# print(match_txt)
# span_txt = match_txt.span()
# print(span_txt)
# start_txt,end_txt=span_txt
# print(start_txt,end_txt)
# sub_string = txt[start_txt:end_txt]
# print(sub_string)

# txt = 'I love to teach python and javaScript'
# match = re.match('I like to teach', txt, re.I)
# print(match)  # None

# txt_search = """Python is the most beautiful language that a human being has ever created.
# I recommend python for a first programming language"""
# match_search = re.search('first',txt_search,re.I)
# print(match_search)

# txt_findall = '''Python is the most beautiful language that a human being has ever created.
# I recommend python for a first programming language'''
# match_findall = re.findall('[Ll]anguage',txt_findall)
# print(match_findall)

# txt_replace = '''Python is the most beautiful language that a human being has ever created.
# I recommend python for a first programming language'''
# match_replace = re.sub('[Pp]ython','JavaScript',txt_replace,re.I)
# print(match_replace)


# txt_sub = '''%I a%m te%%a%%che%r% a%n%d %% I l%o%ve te%ach%ing.
# T%he%re i%s n%o%th%ing as r%ewarding a%s e%duc%at%i%ng a%n%d e%m%p%ow%er%ing p%e%o%ple.
# I fo%und te%a%ching m%ore i%n%t%er%%es%ting t%h%an any other %jobs.
# D%o%es thi%s m%ot%iv%a%te %y%o%u to b%e a t%e%a%cher?'''

# matches = re.sub('%', '', txt_sub)
# print(matches)

# txt_split = '''I am teacher and  I love teaching.
# There is nothing as rewarding as educating and empowering people.
# I found teaching more interesting than any other jobs.
# Does this motivate you to be a teacher?'''
# print(re.split('\n',txt_split))

# regex_pattern = r'[Aa]pple'
# regex_or_pattern = r'[Aa]pple|[Bb]anana'
# txt_regex = 'Apple and banana are fruits. An old cliche says an apple a day a doctor way has been replaced by a banana a day keeps the doctor far far away.'
# matches = re.findall(regex_pattern,txt_regex)
# print(matches)

# regex_d = r'\d'
# regex_d_more = r'\d+'

# txt_d = 'This regular expression example was made on December 6,  2019 and revised on July 8, 2021'
# print(re.findall(regex_d,txt_d))
# print(re.findall(regex_d_more,txt_d))

# regex_period = r'[Aa].+'
# txt_period = '''Apple and banana are fruits'''
# print(re.findall(regex_period,txt_period))

# regex_star = r'[a].*'
# txt_star = '''Apple and banana are fruits'''
# print(re.findall(regex_star,txt_star))

# regex_q = r'[Ee]-*mail'
# txt_q = '''I am not sure if there is a convention how to write the word e-mail.
# Some people write it as email others may write it as Email or E-mail.'''
# print(re.findall(regex_q,txt_q))

# txt_qt = 'This regular expression example was made on December 6,  2019 and revised on July 8, 2021'
# regex_qt = r'\d{4}'
# print(re.findall(regex_qt,txt_qt))

# txt_cart = 'This regular expression example was made on December 6,  2019 and revised on July 8, 2021'
# regex_cart = r'^This'
# print(re.findall(regex_cart,txt_cart))

# txt_ng = 'This regular expression example was made on December 6,  2019 and revised on July 8, 2021'
# regex_ng = r'[^A-Za-z ]+'
# print(re.findall(regex_ng,txt_ng))


"""exercises"""
import re
paragraph = 'I love teaching. If you do not love teaching what else can you love. I love Python if you do not love something which can give you all the capabilities to develop an application what else can you love.'
regex_word = r'\w+'
words = re.findall(regex_word,paragraph)
max_count = 0
max_count_word = ''
for word in words:
    word_count = words.count(word)
    if(word_count>max_count):
        max_count = word_count
        max_count_word = word
print(f'max word is {max_count_word}, count is {max_count}')

points = ['-1', '2', '-4', '-3', '-1', '0', '4', '8']
points.sort()
print(points)
min_value = int(points[0])
max_value = int(points[-1])
print(max_value-min_value)

def is_valid_variable(variable_str):
    regex_var = r'^[A-Za-z_][A-z0-9_]*$'
    match = re.match(regex_var,variable_str)
    return bool(match)
print(is_valid_variable('first_name'))

sentence = '''%I $am@% a %tea@cher%, &and& I lo%#ve %tea@ching%;. There $is nothing; &as& mo@re rewarding as educa@ting &and& @emp%o@wering peo@ple. ;I found tea@ching m%o@re interesting tha@n any other %jo@bs. %Do@es thi%s mo@tivate yo@u to be a tea@cher!?'''
regex_per = r'[^A-z\s]'
clear_sentence = re.sub(regex_per,'',sentence)
print(clear_sentence)

regex_word = r'\w+'
clear_words = re.findall(regex_word,clear_sentence)
word_freq = dict()
# Count the frequency of each word
for word in words:
    if word in word_freq:
        word_freq[word] += 1
    else:
        word_freq[word] = 1
freq_frist = max(word_freq,key=word_freq.get)
word_freq.pop(freq_frist)
freq_second = max(word_freq,key=word_freq.get)
print(freq_frist,freq_second)

