﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _02PointInRectangle
{
    public class Point
    {
        public Point(int coordinateX, int coordinateY)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
        }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
    }
}
