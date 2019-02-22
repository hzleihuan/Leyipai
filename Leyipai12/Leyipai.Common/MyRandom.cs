﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Leyipai.Common
{
   public class MyRandom
    {

      

        /// <summary>
        /// 生成随机数字字符串
        /// </summary>
        /// <param name="codeCount">待生成的位数</param>
        /// <returns>生成的数字字符串</returns>
       public static string GenerateCheckCodeNum(int codeCount)
       {
           int rep = 0;
           string str = string.Empty;
           long num2 = DateTime.Now.Ticks + rep;
           rep++;
           Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
           for (int i = 0; i < codeCount; i++)
           {
               int num = random.Next();
               str = str + ((char)(0x30 + ((ushort)(num % 10)))).ToString();
           }
           return str;
       }


       /// <summary>
       /// 生成随机字母字符串(数字字母混和)
       /// </summary>
       /// <param name="codeCount">待生成的位数</param>
       /// <returns>生成的字母字符串</returns>
       public static string GenerateCheckCode(int codeCount)
       {
           int rep = 0;
           string str = string.Empty;
           long num2 = DateTime.Now.Ticks + rep;
           rep++;
           Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
           for (int i = 0; i < codeCount; i++)
           {
               char ch;
               int num = random.Next();
               if ((num % 2) == 0)
               {
                   ch = (char)(0x30 + ((ushort)(num % 10)));
               }
               else
               {
                   ch = (char)(0x41 + ((ushort)(num % 0x1a)));
               }
               str = str + ch.ToString();
           }
           return str;
       }


       /// <summary>
       /// 得到一个销售订单号
       /// </summary>
       /// <returns></returns>
       public static string GetSalesOrderID()
       {
           int rep = 0;
           string str = string.Empty;
           long num2 = DateTime.Now.Ticks + rep;
           rep++;
           Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
           for (int i = 0; i < 3; i++)
           {
               int num = random.Next();
               str = str + ((char)(0x30 + ((ushort)(num % 10)))).ToString();
           }
           return "S"+DateTime.Now.ToString("yyyyMMddHHmmss")+str;
       }

    }
}
