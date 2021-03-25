// /ab+c/i; //字面量形式
// 首个参数为字符串模式的构造函数
let newRegex = new RegExp("ab+c", "i");
// 首个参数为常规字面量的构造函数
let newRegex1 = new RegExp(/ab+c/, "i");

// 使用正则改变数据结构
let re = /(\w+)\s(\w+)/;
let str = "John Smith";
let newStr = str.replace(re, "$2,$1");
console.log(newStr);

// 使用正则来划分带有多种行结束符和换行符的文本
var text = "Some text\nAnd some more\r\nAnd yet\rThis is the end";
console.log(text.split(/\r\n|\r|\n/));

// 在多行文本中使用正则表达式
var s = "Please yes\nmake my day!";
console.log(s.match(/yes.*day/));
console.log(s.match(/yes[^]*day/));

// sticky 标志和 global 标志的不同点
let rex2 = /\d/g;
while ((r = rex2.exec("123 456")))
  console.log(r, "And rex2.lastIndex", rex2.lastIndex);

// 使用正则表达式和 Unicode 字符
let unicodeText = "Образец text на русском языке";
let unicodeRegex = /[\u0400-\u04FF]+/g;
let match = unicodeRegex.exec(unicodeText);
console.log(match[1]);
console.log(unicodeRegex.lastIndex);
let match2 = unicodeRegex.exec(unicodeText);
console.log(match2[1]);
console.log(unicodeRegex.lastIndex);

// 从 URL 中提取子域名
var url = "http://xxx.domain.com";
let urlRegex = /[^.]+/;
console.log(urlRegex.exec(url)[0].substr(7));
