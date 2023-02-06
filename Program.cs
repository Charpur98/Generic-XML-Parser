using System;
using System.Text;
using System.Xml;

public static class xmlParser
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Charpurs XML Parser!");
        string filePath = "./xmlfiles/test.xml";
        System.Xml.XmlDocument xmlFile = loeadXml(filePath);
        if (xmlFile != null)
        {
            processNodes(xmlFile.ChildNodes);
            searchChildNode("Data", searchNode("Information", xmlFile));
            string result = getAttributeValue("title", searchChildNode("Data", searchNode("Information", xmlFile)));
            Console.WriteLine(result);
        }
    }

    public static System.Xml.XmlDocument loeadXml(string filepath)
    {
        System.Xml.XmlDocument xmlFile = new System.Xml.XmlDocument();
        try
        {
            xmlFile.Load(filepath);
        }
        catch (Exception e)
        {
            Console.WriteLine("Could not load xml file at " + filepath);
            Console.WriteLine(e);
        }

        return xmlFile;
    }

    public static void processNodes(XmlNodeList nodeList)
    {
        //Loop through the Nodes.
        foreach (XmlNode node in nodeList)
        {
            Console.WriteLine(node.Name);
            if (node.HasChildNodes)
                processNodes(node.ChildNodes);
        }
    }

    public static System.Xml.XmlNode? searchNode(string nodeName, System.Xml.XmlDocument xmlFile)
    {
        System.Xml.XmlNode node = null;
        try
        {
            node = xmlFile.SelectSingleNode(nodeName);
        }
        catch (Exception e)
        {
            Console.WriteLine("Could not find node (" + nodeName + ")");
            Console.WriteLine(e);
        }
        return node;
    }

    public static System.Xml.XmlNode? searchChildNode(string nodeName, System.Xml.XmlNode node)
    {
        System.Xml.XmlNode childNode = null;
        foreach (XmlNode row in node.ChildNodes)
        {
            if (row.Name == nodeName)
            {
                childNode = row;
                break;
            }
            foreach (XmlNode mon in row.ChildNodes)
            {
                if (mon.Name == nodeName)
                {
                    childNode = mon;
                    break;
                }
            }
        }
        return childNode;
    }

    public static string getAttributeValue(string attributeName, System.Xml.XmlNode node)
    {
        string attribute = null;
        var a = node.Attributes[attributeName];
        if (a != null)
        {
            attribute = a.Value;
        }

        return attribute;
    }
}
