using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Common {

    public static string access_token = "";
    public static string token_type = "";
    public static string client_id = "";
    public static string client_secret = "";

    public static BuySellScreenToVR_Data buySellScreenToVR_Data;
}

public class BuySellScreenToVR_Data {

    public hotspotContainer[] HotspotData;
    public string VideoURL;
    public string TokenID;
}