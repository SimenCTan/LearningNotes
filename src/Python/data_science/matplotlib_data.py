import matplotlib.pyplot as plt
import numpy as np
from scipy.stats import norm

# x_values = [1,2,3,4,5]
# y_values = [1,4,9,16,25]

# plt.plot(x_values,y_values,color="red")
# plt.scatter(x_values,y_values,color="blue")
# plt.xlabel("X-axis")
# plt.ylabel("Y-axis")
# plt.title("Simple Line Plot")
# plt.show()

# plot bar chart
# cat = ["cat","dog","cow","goat"]
# cat_values = [10,20,30,40]

# plt.bar(cat,cat_values,color="forestgreen")
# plt.xlabel("Categories")
# plt.ylabel("Values")
# plt.title("Simple Bar Plot")
# plt.show()

# plot histogram
x_normal = np.random.normal(0,1,1000)
plt.hist(x_normal,bins=30,color="purple")
plt.xlabel("X-axis")
plt.ylabel("Frequency")
plt.title("Simple Histogram")
# plt.show()

x_values = np.arange(-3,3,0.1)
y_values = norm.pdf(x_values)
counts,bins,ignored = plt.hist(x_normal,30,density=True,color="forestgreen",label="Simple Histogram")
plt.plot(x_values,y_values,color="red",label="Normal Distribution")
plt.title("Simple Histogram with Normal Distribution")
plt.ylabel("Frequency")
plt.legend()
plt.show()
