using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyingListData : MonoBehaviour {

    [System.Serializable]
    public struct BuyListContainer
    {

        public string _id;
        public string updatedAt;
        public string createdAt;
        public string ownerId;
        public string isPreDeveloped;
        public string address;
        public string country;
        public string zip;
        public string squareFeet;
        public string bed;
        public string bath;
        public string sellOrRent;
        public string price;
        public string rentalAmount;
        public string homeTheatre;
        public string status;
        public string information;
        public appointmentDatesContainer[] appointmentDate;
        public string __v;
        public Owner owner;
        public string isFavorite;
    }
    [System.Serializable]
    public struct appointmentDatesContainer
    {
        public string date;
        public string preferedTime;
    }
    [System.Serializable]
    public struct DistanceWillingToTravel
    {
        public string distance;
        public string unit;
    }

    [System.Serializable]
    public struct Owner
    {
        public string _id;
        public string updatedAt;
        public string createdAt;
        public string email;
        public string countryCode;
        public string mobile;
        public string password;
        public string[] acceptedListingIds;
        public string[] favoriteListingIds;
        public string isMobileVerified;
        public string __v;
        public string otpCode;
        public string otpCodeTimeStamp;
        public string basecity;
        public DistanceWillingToTravel distanceWillingToTravel;
        public string linkToPortfolio;
        public string name;
        public string profession;
        public string realEstateLicenseNumber;
        public string zip;
        public string profilePhotoUrl;

    }

    public int NoOfElements;
    public BuyListContainer[] BuyData;
    public appointmentDatesContainer[] appointmentDates;

    // Use this for initialization
    void Start () {
		
	}
    public void ListData()
    {
        BuyData = new BuyListContainer[NoOfElements];
    }
    // Update is called once per frame
    void Update () {
		
	}
}
