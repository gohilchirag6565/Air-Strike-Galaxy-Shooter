
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using UnityEngine;

public class EditManifestAdmob : MonoBehaviour
{
    public static EditManifestAdmob instance;
    
    private const string META_AD_MANAGER_APP = "com.google.android.gms.ads.AD_MANAGER_APP";

    private const string META_APPLICATION_ID  = "com.google.android.gms.ads.APPLICATION_ID";
    
    private const string META_DELAY_APP_MEASUREMENT_INIT =
        "com.google.android.gms.ads.DELAY_APP_MEASUREMENT_INIT";

    private XNamespace ns = "http://schemas.android.com/apk/res/android";
    
    private void Awake()
    {
        instance = this;
    }

    public void ChangeAppIdOnMenifest()
    {
        Debug.Log("<color=red> ChangeAppIdOnMenifest </color>");
        string manifestPath = Path.Combine(
            Application.dataPath, "Plugins/Android/GoogleMobileAdsPlugin.androidlib/AndroidManifest.xml");
        
        XDocument manifest = null;
        try
        {
            Debug.Log("<color=red> try to get manifest </color>");
            manifest = XDocument.Load(manifestPath);
            Debug.Log("<color=red> complete get manifest </color>");
        }
#pragma warning disable 0168
        catch (IOException e)
#pragma warning restore 0168
        {
            //StopBuildWithMessage("AndroidManifest.xml is missing. Try re-importing the plugin.");
            Debug.Log("AndroidManifest.xml is missing. Try re-importing the plugin.");
        }
        
        XElement elemManifest = manifest.Element("manifest");
        if (elemManifest == null)
        {
            //StopBuildWithMessage("AndroidManifest.xml is not valid. Try re-importing the plugin.");
            Debug.Log("AndroidManifest.xml is not valid. Try re-importing the plugin.");
        }
        
        XElement elemApplication = elemManifest.Element("application");
        if (elemApplication == null)
        {
            //StopBuildWithMessage("AndroidManifest.xml is not valid. Try re-importing the plugin.");
            Debug.Log("AndroidManifest.xml is not valid. Try re-importing the plugin.");
        }
        
        
        IEnumerable<XElement> metas = elemApplication.Descendants().Where( elem => elem.Name.LocalName.Equals("meta-data"));

        XElement elemAdManagerEnabled = GetMetaElement(metas, META_AD_MANAGER_APP);

        XElement elemAdMobEnabled = GetMetaElement(metas, META_APPLICATION_ID);

        elemManifest.Save(manifestPath);
    }
    
    private XElement GetMetaElement(IEnumerable<XElement> metas, string metaName)
    {
        foreach (XElement elem in metas)
        {
            IEnumerable<XAttribute> attrs = elem.Attributes();
            foreach (XAttribute attr in attrs)
            {
                if (attr.Name.Namespace.Equals(ns)
                    && attr.Name.LocalName.Equals("name") && attr.Value.Equals(metaName))
                {
                    return elem;
                }
            }
        }
        return null;
    }
    
    private XElement CreateMetaElement(string name, object value)
    {
        return new XElement("meta-data",
            new XAttribute(ns + "name", name), new XAttribute(ns + "value", value));
    }
}
