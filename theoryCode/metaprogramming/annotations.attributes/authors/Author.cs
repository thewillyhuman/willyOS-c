using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Can only be applied to classes and structs
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class AuthorAttribute : Attribute {
    public AuthorAttribute(string name) {
        this.name = name;
        this.version = 0;
        this.tested = false;
        this.date = default(DateTime);
    }

    public AuthorAttribute(string name, uint version,bool tested, string date) {
        this.name = name;
        this.version = 0;
        this.tested = tested;
        this.date = DateTime.Parse(date);
    }

    public string Name {
        get {
            return name;
        }
    }

    public uint Version {
        get {
            return version;
        }
    }

    public bool Tested {
        get {
            return tested;
        }
    }

    public override string ToString() {
        string valor = "Author: " + Name;
        if (version != 0) {
            valor += ", Version: " + Version.ToString();
        }
        valor += ", Tested: " + (this.Tested ? "Yes" : "No");
        if (date!=default(DateTime))
            valor += ", Date: " + this.date.ToShortDateString();
        return valor;
    }

    private string name;
    private uint version;
    private bool tested;
    private DateTime date;
}
