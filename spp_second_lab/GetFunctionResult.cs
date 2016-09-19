using System;

namespace spp_second_lab_tests
{
    internal class GetFunctionResult
    {
        public int GetRuslt(int i, int j)
        {
            return i + j;
        }
        public string GetEasyString(string str1,string str2, string str3)
        {
            return string.Concat(str1, str2,str3);
        }
        public bool CheckOnGoodPerson(string str,int age,bool alive)
        {
            if ((str == "Sasha") && (age == 20) && (alive))
                return true;
            else
                return false;
        }

        internal void EmptyFunc()
        {
            throw new NotImplementedException();
        }
    }
}