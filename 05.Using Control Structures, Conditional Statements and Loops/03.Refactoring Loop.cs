bool valueFoundFlag = false;

for (int i = 0; i < 100; int++) 
{
   if (i % 10 == 0)
   {
		if ( array[i] == expectedValue ) 
		{
			valueFoundFlag = true;
		}
   }
   
   Console.WriteLine(array[i]);
}

// More code here
if (valueFoundFlag) {
	Console.WriteLine("Value Found");
}