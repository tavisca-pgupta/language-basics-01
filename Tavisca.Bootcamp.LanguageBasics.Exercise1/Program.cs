using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
	class Program
	{
		static void Main(string[] args)
		{
			Test("42*47=1?74", 9);
			Test("4?*47=1974", 2);
			Test("42*?7=1974", 4);
			Test("42*?47=1974", -1);
			Test("2*12?=247", -1);
			//Console.ReadKey(true);
		}

		private static void Test(string args, int expected)
		{
			var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
			Console.WriteLine($"{args} : {result}");
		}
		
		public static int FindMissingIndex(string num) //To find the position of missing digit
		{
			int i;
			for(i=0;i<num.Length;i++) 
			{
				if(num[i]=='?')
				{
					break;
				}
			}	
			return i;
		}

		public static int FindDigit(string equation)
		{
			// Add your code here.
			string num1,num2,num3;
			int result=-1;
			var numbers = equation.Split("*");
			
			num1 = numbers[0];
			
			numbers=numbers[1].Split("=");
			
			num2=numbers[0];
			num3=numbers[1];
			
			if(num1.Contains("?"))
			{
				int n1,n2,n3,missing_index=0,i;
				n2=Convert.ToInt32(num2);
				n3=Convert.ToInt32(num3);
				
				missing_index=FindMissingIndex(num1);
				
				if(missing_index==0) //Check for leading zeros
					i=1;
				else
					i=0;
				
				for(;i<10;i++)
				{
					string num1_temp = num1.Substring(0,missing_index) + i + num1.Substring(missing_index+1);
					n1 = Convert.ToInt32(num1_temp);
					
					if(n1*n2==n3)
					{
						result=i;
						break;
					}
					
				}							
			}
			else if(num2.Contains("?"))
			{
				int n1,n2,n3,missing_index=0,i;
				n1=Convert.ToInt32(num1);
				n3=Convert.ToInt32(num3);
				
				missing_index=FindMissingIndex(num2);
				
				
				if(missing_index==0) //For checking leading zeros
					i=1;
				else
					i=0;
				
				for(;i<10;i++)
				{
					string num2_temp = num2.Substring(0,missing_index) + i + num2.Substring(missing_index+1);
					n2 = Convert.ToInt32(num2_temp);
					
					if(n1*n2==n3)
					{
						result=i;
						break;
					}	
				}	
				
			}
			else if(num3.Contains("?"))
			{
				int n1,n2,n3,missing_index=0,i;
				n1=Convert.ToInt32(num1);
				n2=Convert.ToInt32(num2);
				
				missing_index=FindMissingIndex(num3);
				
				if(missing_index==0) //Check for leading zeros
					i=1;
				else
					i=0;
				
				for(;i<10;i++)
				{
					string num3_temp = num3.Substring(0,missing_index) + i + num3.Substring(missing_index+1);
					n3 = Convert.ToInt32(num3_temp);
					
					if(n1*n2==n3)
					{
						result=i;
						break;
					}
					
				}							
			}
			
			return result;
		}
	}
}
