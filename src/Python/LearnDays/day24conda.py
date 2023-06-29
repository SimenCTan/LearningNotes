import numpy as np
import matplotlib
import seaborn as sns
import matplotlib.pyplot as plt

# How to check the version of the numpy package
# print('numpy:', np.__version__)
# Checking the available methods
# print(dir(np))

python_list = [1,2,3,4]
two_dimensional_list = [[0,1,2], [3,4,5], [6,7,8]]
numpy_array_from_list = np.array(two_dimensional_list)
print(numpy_array_from_list)
print(np.array(python_list,dtype=float))

print(matplotlib.__name__)
np_normal_dis = np.random.normal(5, 0.5, 1000) # mean, standard deviation, number of samples
plt.hist(np_normal_dis, color="grey", bins=21)
plt.show()

temp = np.array([1,2,3,4,5])
pressure = temp * 2 + 5
plt.plot(temp,pressure)
plt.xlabel('Temperature in oC')
plt.ylabel('Pressure in atm')
plt.title('Temperature vs Pressure')
plt.xticks(np.arange(0, 6, step=0.5))
plt.show()

mu = 28
sigma = 15
samples = 100000

x = np.random.normal(mu, sigma, samples)
ax = sns.distplot(x);
ax.set(xlabel="x", ylabel='y')
plt.show()
