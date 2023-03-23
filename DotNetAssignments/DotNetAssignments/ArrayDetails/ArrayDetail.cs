namespace DotNetAssignments.ArrayDetails
{
    public class ArrayDetail
    {
        int[] arr;
        public int MinValueInArray { get; set; }
        public int MaxValueInArray { get; set; }
        public int SumOfValuesInArray { get; set; }        
        public Dictionary<int, int> UniqueValuesWithCount=new Dictionary<int, int>();
        public List<int> OddElement=new List<int>();
        public List<int> EvenElement=new List<int>();
        public ArrayDetail()
        {
        option:
            Console.Write("Enter the Number of elements you want to store:");
            if (!int.TryParse(Console.ReadLine(), out int elements))
            {
                Console.WriteLine("Please enter the valid data");
                goto option;
            }
            arr = new int[elements];            
            for (int i = 0; i < elements; i++)
            {
                Console.Write("Enter {0} element:", i+1);
                while (!int.TryParse(Console.ReadLine(), out arr[i]))
                {
                    Console.WriteLine("Please enter the valid data");
                }
            }            
            MinValueInArray = arr[0];
            MaxValueInArray = arr[0];
            SumOfValuesInArray = 0;
            for (int i = 0; i < arr.Length; i++)
            {                                
                SumOfValuesInArray += arr[i];
                if (MinValueInArray > arr[i])
                {
                    MinValueInArray = arr[i];
                }
                if (MaxValueInArray < arr[i])
                {
                    MaxValueInArray = arr[i];
                }
                if (arr[i] % 2 == 1)
                {
                    OddElement.Add(arr[i]);                   
                }
                else if (arr[i] % 2 == 0)
                {
                    EvenElement.Add(arr[i]);
                }
                if (UniqueValuesWithCount.ContainsKey(arr[i]))
                {
                    UniqueValuesWithCount[arr[i]] = ++UniqueValuesWithCount[arr[i]];
                }
                else
                {
                    UniqueValuesWithCount.Add(arr[i], 1);
                }
            }
        }
    }
}
