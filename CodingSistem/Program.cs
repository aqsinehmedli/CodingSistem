using System;

//Directory.CreateDirectory(@"C:\Users\User\OneDrive - ITM STEP MMC\Desktop");

//var directories = Directory.GetDirectories(@"C:\Users\User\OneDrive - ITM STEP MMC\Desktop");

//foreach (var directory in directories)
//    Console.WriteLine(directory);

//var files = Directory.GetFiles(@"C:\Users\User\OneDrive - ITM STEP MMC\Desktop");

//foreach (var file in files)
//    Console.WriteLine(file);

// C:\Users\User\OneDrive - ITM STEP MMC\Desktop\salam.png
// C:\Users\User\OneDrive - ITM STEP MMC\Desktop\Aqsin

void copyFile(string sources, string destinations)
{
    if (File.Exists(sources))
    {
        try
        {
            using (var sourceStream = new FileStream(sources, FileMode.Open, FileAccess.Read))
            {

                if (!Path.HasExtension(destinations)) 
                {
                    destinations = $@"{destinations}\{Path.GetFileNameWithoutExtension(sources)}Copy{Path.GetExtension(sources)}";
                }

                if (Path.GetExtension(sources) == Path.GetExtension(destinations))
                {
                    using (var destStream = new FileStream(destinations, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        var len = 200;
                        var bytes = new byte[len];
                        do
                        {
                            len = sourceStream.Read(bytes, 0, len);
                            destStream.Write(bytes, 0, len);
                            Thread.Sleep(10);

                        } while (0 < len);

                    }
                }
                else
                {
                    Console.WriteLine("Duzgun file extension secin");
                    Console.ReadKey();

                }


            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong");
            // ex.Message log
        }
    }
    else
    {
        Console.WriteLine("File tapilmadi");
        Console.WriteLine("Press enter for continue");
        Console.ReadKey();
    }
}

while (true)
{
    Console.Write("Source path: ");
    var source = Console.ReadLine()!;
    Console.Write("Destination Path: ");
    var destination = Console.ReadLine()!;

     // single thread

    var thread = new Thread(() =>
    {
        copyFile(source, destination);
    });
    thread.Start();

}