using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CodeLogOut
{
    class CCodeContent : InterfaceCodeLog
    {
    
        public string GetCode( string code)
        {
            string new_code;
            //这里提取可能有很多方式,
            //方式一
            //加载数据,取得所有的方法函数,然后把所有的更新放到新的变量里
            new_code = GetCodeFunc1(code);
            return new_code;
        }

        private string GetCodeFunc1(string code)
        {
            //取所有的括号
            //过滤掉不正确的括号
            //定位
            //插入log
            List<string> ListSign = new List<string>();

            MatchCollection mc = Regex.Matches(code, @"(?<name>\w*?)[ ]{0,}\((?<param>[\s\S]*?)\)");
            foreach (var item in mc)
            {

                Match ma = (Match)item;
                Console.WriteLine(ma.Value);
                string funname = ma.Groups["name"].Value;
                //对方法名进行判断
                if (CheckFuncName(funname) == false)
                {
                    continue;
                }
                string param = ma.Groups["param"].Value;
                //对参数进行判断
                if (isParam(param) == false)
                {
                    continue;
                }
                //查看方法后两个字符是什么
                //如果是;那么是定义,无需要理会
                //如果是{那么是方法
                if (CheckFunctionAfter(code,ma.Value) == false)
                {
                    continue;
                }
                //方法被注释过滤
                if (item.ToString().StartsWith("//"))
                {
                    continue;
                }
                //重复数据过滤
                if (ListSign.Contains(item.ToString()))
                {
                    continue;
                }
                ListSign.Add(item.ToString());
            }
            StringBuilder sb = new StringBuilder();
            foreach (string item in ListSign)
            {
                sb.AppendLine(item+"---");
            }
            System.IO.File.WriteAllText("functionname.txt", sb.ToString());
            return "";
        }

        private bool CheckFunctionAfter(string code, string str)
        {
            bool result = false;
            int indexstart =0;//每次查找到的字符串所在位置
            while (indexstart != -1)
            {
                indexstart = code.IndexOf(str, indexstart+1);//每次查找到的字符串所在位置
                if (indexstart <= -1)
                {
                    return false;
                }
                if (indexstart > 0)
                {
                    int indexend = code.IndexOf(";", indexstart + str.Length);   //字符串后的;号与该字符串的位置
                    indexend += 1 ;
                    if (indexend > 0)
                    {
                        int tmpindex = (indexend - (indexstart+str.Length));
                        if (tmpindex > 0)
                        {
                            //取字符串
                            string tmp = code.Substring((indexstart + str.Length), tmpindex);
                            tmp = CheckFilterSpaceEnter(tmp).Trim();
                            if (tmp.StartsWith(";") == true)
                            {
                                //说明是方法定义,所以跳过
                                    //如果第二次又碰到这个函数,并且是函数体,那么查找
                                result = false;
                            }
                            else if (tmp.StartsWith("/*") == true)
                            {
                                //说明是方法定义,所以跳过
                                return  true;
                            }
                            else if (tmp.StartsWith("//") == true)
                            {
                                //说明是方法定义,所以跳过
                                return true;
                            }
                            else if (tmp.StartsWith("{") == true)
                            {
                                //说明是方法定义,所以跳过
                                return true;
                            }
                            else
                            {
                                System.IO.File.AppendAllText("tmp.txt", tmp);
                            }

                        }
                        else
                        {
                            //要提取的字符串长度为0或为负数
                            continue;
                        }

                    }
                    else
                    {
                        //todo
                        continue;
                    }
                }
                else
                {
                    //todo
                }
                indexstart = indexstart + str.Length;
            }

            return result;
        }

        private int GetIndexFunNameIndex(string code, string str)
        {
            int tmpindex = code.IndexOf(str) ;
            if (tmpindex > -1)
            {
                return tmpindex + str.Length;
            }
            else 
            {
                return 0;
            }
        }

        private bool CheckFuncName(string name)
        {
            name = CheckFilterSpaceEnter(name).Trim();
            List<string> listitem = new List<string>();
            listitem.Add("if");
            listitem.Add("while");
            listitem.Add("for");
            listitem.Add("foreach");
            listitem.Add("do");
            listitem.Add("else if");
            listitem.Add("ifeq");
            listitem.Add("switch");
            listitem.Add("defined");
            listitem.Add("return");
            listitem.Add("");
            foreach (string item in listitem)
            {
                if (item == name)
                {
                    return false;
                }
            }
            return true;
        }

        private bool isParam(string param)
        {
            param = CheckFilterSpaceEnter(param).Trim();
            if (param.Contains(","))
            {
                string[] strparams = param.Split(',');
                foreach (string itempara in strparams)
                {
                    string itemparamstr = itempara.Trim();
                    itemparamstr = CheckFilterSpaceEnter(itemparamstr);
                    string[] itemparamkv = itemparamstr.Split(' ');
                    if (itemparamkv.Length<2)
                    {
                        return false;
                    }
                    foreach (string itemkv in itemparamkv)
                    {
                        string value = itemkv.Replace(" ","");
                        if (value == "")
                        {
                            return false;
                        }
                    }
                }
            }
            else if (param.ToLower() == "void")
            {
                return true;
            }
            else if (param == "")
            {
                return true;
            }
            else
            {
                //只有一个参数
                param = CheckFilterSpaceEnter(param);
                string[] itemparamkv = param.Split(' ');
                if (itemparamkv.Length<1)   //至少有两个才能正确,因为前面是类型,后面是变量
                {
                    return false;
                }
                foreach (string itemkv in itemparamkv)
                {
                    string value = itemkv.Replace(" ", "");
                    if (value == "")
                    {
                        return false;   //只要有一个 
                    }
                }
            }
            return true;
        }

        private string CheckFilterSpaceEnter(string itemparamstr)
        {
            while (itemparamstr.Contains("  ") == true)
            {
               itemparamstr = itemparamstr.Replace("  ", " ");
            }
             itemparamstr = itemparamstr.Replace("\r", "");
             itemparamstr = itemparamstr.Replace("\n", "");
             itemparamstr = itemparamstr.Replace("\t", "");
            return itemparamstr;
        }
    }
}
