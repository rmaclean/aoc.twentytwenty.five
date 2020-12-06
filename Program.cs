using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var fileData = await File.ReadAllLinesAsync("data.txt");
var seatData = fileData.AsParallel().Select(raw => new Seat(raw)).ToArray();

var highestSeat = seatData.Max(seat => seat.ID);
Console.WriteLine($"💺 {highestSeat}");