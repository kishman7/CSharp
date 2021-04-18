using System;
using System.Collections.Generic;
using System.Text;

namespace BildHouse
{
    class Basement : IPart
    {
        public string Material { get => material.ToString(); }
        public char MaterialChar => (Char)material.GetHashCode();

        static Style material;
        public static Style MaterialStyle
        {
            set => material = value;
            get=>material;
        }
        public enum Style
        {
            tape = 126,
            columnar = 88,
            solid = 35
        }

    }
    class Walls : IPart
    {
        public string Material { get => material.ToString(); }
        public char MaterialChar => (Char)material.GetHashCode();
        static Style material;
        public static Style MaterialStyle
        {
            set => material = value;
            get => material;
        }
        public enum Style
        {
            brick = 61,
            concrete = 64
        }
    }
    class Door : IPart
    {
        public string Material { get => material.ToString(); }
        public char MaterialChar => (Char)material.GetHashCode();
        static Style material;
        public static Style MaterialStyle
        {
            set => material = value;
            get => material;
        }
        public enum Style
        {
            metal = 91,
            tree = 42
        }
    }
    class Window : IPart
    {
        public string Material { get => material.ToString(); }
        public char MaterialChar => (Char)material.GetHashCode();
        static Style material;
        public static Style MaterialStyle
        {
            set => material = value;
            get => material;
        }
        public enum Style
        {
            glass = 79,
            glass2 = 87
        }
    }
    class Roof : IPart
    {   
        public string Material { get => material.ToString(); }
        public char MaterialChar => (Char)material.GetHashCode();
        static Style material;
        public static Style MaterialStyle
        {
            set => material = value;
            get => material;
        }
        public enum Style
        {
            slate = 62,
            tiling = 60
        }
    }
}
