import math
# a=2+3j
# b=-1+2j
# print(a*b)
# print(a/b)

# x=3
# x>>=1
# print(x)
# x<<=3
# print(x)
# x^=3
# print(x)
# x&=3
# print(x)
# x|=3
# print(x)

# print("get triangle perimeter pls enter three side")
# a_side=float(input('Pls enter a side:'))
# b_side=float(input('pls enter b side:'))
# c_side=float(input('pls enter c side:'))
# print(f'the perimeter of triangle is {a_side+b_side+c_side:.2f}')

# 计算二元一次方程截距和斜率
# find_slope=lambda x:2*x-2
# slope_8=2
# x_intercept=1
# y_intercept=find_slope(0)
# print(f'slope:{slope_8}')
# print(f'x intercept:(0,{x_intercept})')
# print('y intercept:(0,{})'.format(y_intercept))

# point1=(2,2)
# point2=(6,10)
# slope_9=(10-2)/(6-2)
# print(slope_9)
# euc_dis = math.sqrt((10-2)**2+(6-2)**2)
# print(euc_dis)

# print((slope_9>slope_8))
# print((slope_9==slope_8))

# 计算一元二次方程组
# 输入方程的系数
# a=float(input('pls input a value'))
# b=float(input('pls input b value'))
# c=float(input('pls input c value'))

# d=b**2-4*a*c
# if d>0:
#     root1=(-b+math.sqrt(d))/(2*a)
#     root2=(-b-math.sqrt(d))/(2*a)
#     print('方程的两个实根为{}；{}'.format(root1,root2))
# elif d==0:
#     root_real =-b/2*a
#     print('方程的唯一实根为{}'.format(root_real))
# else:
#     real = -b/2*a
#     img = math.sqrt(-d)/2*a
#     print('方程的两个虚根为{}+{}j；{}-{}j'.format(real,img,real,img))

# eqn = lambda x :x**2+6*x+9
# x_values=[-4, -3, -2, -1, 0, 1, 2, 3, 4]
# y_values=[ eqn(x) for x in x_values]
# for x,y in zip(x_values,y_values):
#     print('when x={},y={}'.format(x,y))

# # find zero y=0 at x?
# zero_x=(-6+math.sqrt(6**2-4*9))/2
# print('x={:.0f} when y=0'.format(zero_x))

# py_str='Python'
# dr_str='dragon'
# print(len(py_str))
# print(len(dr_str))
# print(py_str==dr_str)
# ispy_has_on = py_str.__contains__('on')
# isdr_has_on = dr_str.__contains__('on')
# print(ispy_has_on and isdr_has_on)
# input_str = 'I hope this course is not full of jargon'
# jargon_index = input_str.index('jargon')
# print(jargon_index)
# print(jargon_index>0)
# py_float = float(len(py_str))
# print(py_float)

row_list=[1,2,3,4,5]
col_list=[0,1,2,3]
for row in row_list:
    print(row,end=' ')
    for col in col_list:
        print(row**col,end=' ')
    print()



