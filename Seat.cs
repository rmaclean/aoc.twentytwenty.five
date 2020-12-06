using System;
public record Seat
{
    public int Row { get; private set; }
    public int Column { get; private set; }
    public int ID { get; private set; }

    private int DetermineRow(string raw)
    {
        var rangeSize = 128;
        var min = 0;
        var max = rangeSize - 1;
        for (var index = 0; index < 7; index++)
        {
            rangeSize /= 2;
            var indicator = raw[index];
            switch (indicator)
            {
                case 'F':
                    {
                        max -= rangeSize;
                        break;
                    }
                case 'B':
                    {
                        min += rangeSize;
                        break;
                    }
            }
        }

        return min;
    }

    private int DetermineCol(string raw)
    {
        var rangeSize = 8;
        var min = 0;
        var max = rangeSize - 1;
        for (var index = 7; index < 10; index++)
        {
            rangeSize /= 2;
            var indicator = raw[index];
            switch (indicator)
            {
                case 'L':
                    {
                        max -= rangeSize;
                        break;
                    }
                case 'R':
                    {
                        min += rangeSize;
                        break;
                    }
            }
        }

        return min;
    }

    public Seat(string raw)
    {
        Row = DetermineRow(raw);
        Column = DetermineCol(raw);
        ID = Row * 8 + Column;
    }
}