using System;
using System.Collections.Generic;
using System.Text;

namespace XiangqiProject
{
    public abstract class Piece
    {
        string name;//名字，颜色，行，列，这是我暂时想到有用的属性
        public int column;
        public int row;
        public string color;
        public bool canGo = false;
        public bool alive = true;
        public bool beProtected = false;

        public Piece(string color, string name, int column, int row)//构造函数
        {
            this.color = color;
            this.name = name;
            this.column = column;
            this.row = row;
        }

        public string GetName()//获取名字
        {
            return this.name;
        }

        public string GetColor()//获取棋子的颜色
        {
            return this.color;
        }

        public bool GetCanGo()
        {
            return this.canGo;
        }

        public bool GetAlve()
        {
            return this.alive;
        }

        public void SetName(string name)//获取名字
        {
            this.name = name;
        }

        public void SetColor(string color)//获取棋子的颜色
        {
             this.color = color;
        }

        public void ChangeCanGo()
        {
             this.canGo = true;
        }




    }
    public class horse : Piece
    {
        public horse(string color, int column, int row)
        : base(color, "马", column, row)
        {
        }
    }

    public class cannon : Piece
    {
        public cannon(string color, int column, int row)
        : base(color, "炮", column, row)
        { }
    }
    public class rood : Piece
    {
        public rood(string color, int column, int row)
        : base(color, "车", column, row)
        { }
    }

    public class soldier : Piece
    {
        public soldier(string color, int column, int row)
        : base(color, "兵", column, row)
        { }

    }

    public class elephant : Piece
    {
        public elephant(string color, int column, int row)
        : base(color, "象", column, row)
        { }
    }

    public class guard : Piece
    {
        public guard(string color, int column, int row)
        : base(color, "士", column, row)
        { }
    }

    public class general : Piece
    {
        public general(string color, int column, int row)
            : base(color, "将", column, row)
        { }
    }

    public class nochess : Piece
    {
        public nochess(int column, int row)
            : base("nochess", "nochess", column, row)
        { }
    }
}