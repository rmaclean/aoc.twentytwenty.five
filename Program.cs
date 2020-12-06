using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var fileData = await File.ReadAllLinesAsync("data.txt");
var seatData = fileData.AsParallel().Select(raw => new Seat(raw)).OrderBy(_ => _.ID).ToArray();

var expectedID = seatData[0].ID + 1;
for (var index = 1; index < seatData.Length -1; index++, expectedID++)
{
   if (seatData[index].ID != expectedID) {
       Console.WriteLine($"Empty seat at {expectedID}");
       break;
   }
}