using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public static partial class IEnumerableTo
{
    public static StringBuilder StringBuilderFrom(IEnumerable i_IEnumerable)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (object currentObject in i_IEnumerable)
        {
            stringBuilder.AppendLine(currentObject.ToString());
        }

        return stringBuilder;
    }

    public static StringWriter StringWriterFrom(IEnumerable i_IEnumerable)
    {
        StringWriter stringWriter = new StringWriter();

        foreach (object currentObject in i_IEnumerable)
        {
            stringWriter.WriteLine(currentObject);
        }

        return stringWriter;
    }

    public static string StringFrom(IEnumerable i_IEnumerable)
    {
        return IEnumerableTo.StringWriterFrom(i_IEnumerable).ToString();
    }

    public static StringBuilder StringBuilderFrom<T>(IEnumerable<T> i_IEnumerable)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (T t in i_IEnumerable)
        {
            stringBuilder.AppendLine(t.ToString());
        }

        return stringBuilder;
    }

    public static StringWriter StringWriterFrom<T>(IEnumerable<T> i_IEnumerable)
    {
        StringWriter stringWriter = new StringWriter();
        foreach (T t in i_IEnumerable)
        {
            stringWriter.WriteLine(t);
        }

        return stringWriter;
    }

    public static string StringFrom<T>(IEnumerable<T> i_IEnumerable)
    {
        return IEnumerableTo.StringWriterFrom<T>(i_IEnumerable).ToString();
    }
}