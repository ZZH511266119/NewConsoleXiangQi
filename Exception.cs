using System;
using System.Collections.Generic;
using System.Text;

namespace XiangqiProject
{
        public class MyException : Exception//这个class没有用，是我想学异常操作复制下来的
        {
            public MyException()
                : base("默认错误测试")
            {

            }

            public MyException(string message)//指定错误消息
                : base(message)
            {

            }

            public MyException(string message, Exception inner)//指定错误消息和内部异常信息
                : base(message, inner)
            {

            }

        }
}
