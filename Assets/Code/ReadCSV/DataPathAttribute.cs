using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class,AllowMultiple =false,Inherited =false)]
public class DataPathAttribute : Attribute
{
    public string filePath { get; set; }
    public DataPathAttribute(string _filePath)
    {
        this.filePath = _filePath;
    }
}
