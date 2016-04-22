using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CodeLogOut
{
    public enum ChunkType
    {
        CODEOUT,
        CODENAMESPACE,
        CODEFUN,
    }
    public class JavaCodeContent : InterfaceCodeLog
    {
        ///都用到哪些方法，最好是能弄出来一个接口
        ///1最终生成的代码，区域块的内容替换
        ///2查询块
        ///2识别块的种类,用于是否加log
        ///

        public JavaCodeContent()
        {
            
        }

        /// <summary>
        /// 返回加log后的代码
        /// </summary>
        /// <param name="codeContent"></param>
        /// <returns></returns>
        public string initCode(string codeContent)
        {
            CodeChunk cc = getCodeChunk(codeContent);

            //区分块
            //对块打log
            string newCode = GetCodeChunkReplace(cc);
            //替换块
            return "";
        }

        private string GetCodeChunkReplace(CodeChunk cc)
        {
            throw new NotImplementedException();
            ///这里有个问题，首先是块不能有相同的，如果有相同的就不好替换了，需要弄成列表形式的
            ///
        }

        private CodeChunk getCodeChunk(string codeContent)
        {
            CodeChunk tmpcc = new CodeChunk();
            string parttn = @"[\S \t]*{[\s\S]*}";
            string code = Regex.Match(codeContent, parttn).Result("$1");
            if (code != null  && code !="" && code.Length>0)
            {
                tmpcc.ChunkStr = code;
                tmpcc.Ct = GetIsChunkType(code);
                tmpcc.ChildChunk.Add(getCodeChunk(tmpcc.ChunkStr));
                return tmpcc;
            }
            else
            {
                return tmpcc;
            }
        }

        private ChunkType GetIsChunkType(string code)
        {
            int len = code.IndexOf('{');
            if (len<1 )
	        {
		         return ChunkType.CODEOUT;
	        }
            string lineone = code.Substring(0, len);
            if (lineone.IndexOf(" class ") > -1)
            {
                return ChunkType.CODEOUT;
            }
            else
            {
                return ChunkType.CODEFUN;
            }
        }

        public string GetCode(string code)
        {
            throw new NotImplementedException();
        }
    }

    public class CodeChunk
    {
        string chunkStr = "";
        /// <summary>
        /// 代码
        /// </summary>
        public string ChunkStr
        {
            get { return ChunkStr; }
            set { ChunkStr = value; }
        }
        ChunkType ct = ChunkType.CODEOUT;
        /// <summary>
        /// 内型
        /// </summary>
        public ChunkType Ct
        {
            get { return ct; }
            set { ct = value; }
        }
        List<CodeChunk> childChunk = null;
        /// <summary>
        /// 子块
        /// </summary>
        public List<CodeChunk> ChildChunk
        {
            get { return childChunk; }
            set { childChunk = value; }
        }
    }
}
