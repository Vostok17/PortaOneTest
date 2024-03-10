string filePath;
bool fileExists;

do
{
    Console.WriteLine("Please enter the path to the file:");
    filePath = Console.ReadLine();

    fileExists = File.Exists(filePath);

    if (!fileExists)
    {
        Console.WriteLine("File not found. Please try again.");
    }
} while (!fileExists);


try
{
    var data = File.ReadLines(filePath);

    int max = int.MinValue;
    int min = int.MaxValue;

    double average = 0;
    int count = 0;

    var maxSeq = new List<int>();
    var minSeq = new List<int>();

    int prev = Convert.ToInt32(data.First());
    var currMax = new List<int> { prev };
    var currMin = new List<int> { prev };

    foreach (string line in data)
    {
        int num = Convert.ToInt32(line);

        if (num > max)
        {
            max = num;
        }

        if (num < min)
        {
            min = num;
        }

        average += num;
        count++;

        if (prev < num)
        {
            currMax.Add(num);
        }
        else
        {
            if (currMax.Count > maxSeq.Count)
            {
                maxSeq = currMax;
            }

            currMax = new List<int> { num };
        }

        if (prev > num)
        {
            currMin.Add(num);
        }
        else
        {
            if (currMin.Count > maxSeq.Count)
            {
                minSeq = currMin;
            }

            currMin = new List<int> { num };
        }

        prev = num;
    }

    average /= count;

    int[] numbers = data.Select(int.Parse).ToArray();
    Array.Sort(numbers);

    double median;
    if (numbers.Length % 2 == 0)
    {
        median = (numbers[numbers.Length / 2 - 1] + numbers[numbers.Length / 2]) / 2.0;
    }
    else
    {
        median = numbers[numbers.Length / 2];
    }

    Console.WriteLine("Max: " + max);
    Console.WriteLine("Min: " + min);
    Console.WriteLine("Median: " + median);
    Console.WriteLine("Average: " + average);
    Console.WriteLine("Increasing sequence:\n" + string.Join(", ", maxSeq));
    Console.WriteLine("Decreasing sequence:\n" + string.Join(", ", minSeq));
}
catch (Exception ex)
{
    Console.WriteLine("Your file is probably in the wrong format.");
    Console.WriteLine(ex);
}