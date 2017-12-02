using System;
using System.Collections.Generic;
using System.Text;

public class CommonEnvironment
{
    static int int_CurrentLanguage = 1;

    public static int CurrentLanguage
    {
        get
        {
            return CommonEnvironment.int_CurrentLanguage;
        }
        set
        {
            CommonEnvironment.int_CurrentLanguage = value;
        }
    }
}

