# Excel2Unity

* 功能

	* 将Excel配表数据导入Unity中，生成二进制配表数据以及相应的读取代码
   
* 安装须知
	
	* 1, 表格生成工具用的语言是python, 使用的是最新的python3，需要安装python3版本安装包	
    	        
    * 2, IDE使用的是`pycharm`, 推荐使用`pycharm`开发python
    
	* 3, 导入`xlrd`包，用来读取Excel文件

* 代码修改
	
	打开`Config.py`文件, 修改几个配置属性
	
	 ```python
    # Excel文件目录
	EXCEL_DIR = "./Excel"
    
    # 数据生成路径
	UnityDataDir = "./../ExcelTest/Assets/StreamingAssets/Config/"
	
	# 代码生成路径
	UnityCodeDir = "./../ExcelTest/Assets/Scripts/Config/"	
    ```
	
	在`Excel2Unity`工程目录下，使用`WinRun.bat`批处理文件，执行生成数据和代码

* Excel配表使用

	![](https://raw.githubusercontent.com/xieliujian/Excel2Unity/master/Snapshots/Doc1.bmp)
	
	* Excel表头有5行

	* 第一行为字段注释，在生成代码中显示

	* 第二行有三个字段可以选择 `C, S, CS` , 分别用来代码这个字段是`客户端所有，服务器所有，还是客户端服务器共有`

	* 第三行是字段的类型, 目前有`int,float,bool,string,list[int],list[float],list[string],map[int|int],map[int|float],map[int|string],map[string|int],map[string|float],map[string|string]`这些类型可供选择, 涵盖了常用的类型

	* 第四行填写字段名

	* 第五行是指字段是否为key，这个表格工具支持多个字段`key`和没有`key`
        
        * 没有`key`的情况下，生成的表格的数据管理类的数据使用`List`管理
        
        * 有一个`key`的情况下，生成的表格的数据管理类的数据使用`Dictionary`管理
        
        * 多个`key`的情况下，也是使用`List`来管理，但是获取数据的函数会有不同可能会有多个形参
    	
    	* 打上`key`关键字的字段只能是`int, string`这几个基本类型

* 特殊说明，在Excel中，对于数组类型字段，需要使用默认的分隔符

	* 对于List字段，分隔符是使用的` ; `(分号)

	* 对于Map字段，一级分隔符是` | `(竖斜杠), 二级分隔符是` ; `(分号)

# 这个工具的知乎文章

[https://zhuanlan.zhihu.com/p/52591971](https://zhuanlan.zhihu.com/p/52591971 "知乎文章")