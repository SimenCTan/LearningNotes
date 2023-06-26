# import datetime
# from datetime import datetime
# from datetime import date
# from datetime import time
# from datetime import timedelta
# print(dir(datetime))
# now = datetime.now()
# print(now)
# print(now.date())
# print(now.day)
# print(now.month)
# print(now.year)
# print(now.hour)
# print(now.minute)
# print(now.timestamp())
# print(int(now.timestamp()))
# print(f'{now.day}/{now.month},{now.hour}:{now.minute}')
# print(now.strftime('%H:%M:%S'))

# date_str = '2023/06/26'
# date_object = datetime.strptime(date_str,'%Y/%m/%d')
# print(date_object)

# d= date(2023,6,23)
# print(d.today())

# time_empty = time()
# print(time_empty)
# time_value = time(12,23,20)
# print(time_value)

# today = date(2023,6,26)
# new_year = date(2024,6,26)
# time_left_for_newyear = new_year - today
# print(time_left_for_newyear)
# t1 = datetime(year=2023,month=6,day=23,hour=0,minute=0,second=0)
# t2 = datetime(year=2023,month=7,day=3,hour=2,minute=0,second=0)
# t2_left_t1 = t2-t1
# print(t2_left_t1)

# timedelta_one = timedelta(days=12,hours=2,minutes=3,seconds=12)
# print(timedelta_one)
# timedelta_two = timedelta(weeks=1,days=12,hours=10,minutes=3,seconds=12)
# print(timedelta_two)
# print(timedelta_two-timedelta_one)

"""excercises"""
from datetime import datetime
from datetime import timedelta
now = datetime.now()
day = now.day
month = now.month
year = now.year
hour = now.hour
minute = now.minute
timestamp = now.timestamp()
f_now = now.strftime('%m/%d/%Y,%H:%M:%S')
print(f_now)
convert_str_to_datetime = '5 December,2019'
convert_datetime = datetime.strptime(convert_str_to_datetime,'%d %B,%Y')
print(convert_datetime)
new_year_now = now.__add__(timedelta(days=365))
print(new_year_now-now)
timestamp_time = datetime(year=1970,month=1,day=1)
print(now-timestamp_time)
