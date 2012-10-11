﻿using System;
using System.Net;
using System.Diagnostics;
using PropertyFinder.Presenter;

namespace PropertyFinder.Model
{
  public class JsonWebPropertySearch : IJsonPropertySearch
  {
    public void FindProperties(string location, int pageNumber, Action<string> callback, Action<Exception> error)
    {
      string url = "http://api.nestoria.co.uk/api?country=uk&pretty=1&action=search_listings&encoding=json&listing_type=buy&place_name="
                    + location;

      WebClient webClient = new WebClient();
      webClient.DownloadStringCompleted += (s, e) =>
      {
        try
        {
          string result = e.Result;
          callback(result);
        }
        catch (Exception ex)
        {
          error(ex);
        }
      };

      webClient.DownloadStringAsync(new Uri(url));
    }

    public void FindProperties(double latitude, double longitude, int pageNumber, Action<string> callback, Action<Exception> error)
    {
      string url = "http://api.nestoria.co.uk/api?country=uk&pretty=1&action=search_listings&encoding=json&listing_type=buy&centre_point=" +
        latitude.ToString() + "," + longitude.ToString();

      WebClient webClient = new WebClient();
      webClient.DownloadStringCompleted += (s, e) =>
      {
        try
        {
          string result = e.Result;
          callback(result);
        }
        catch (Exception ex)
        {
          error(ex);
        }
      };

      webClient.DownloadStringAsync(new Uri(url));
    }
  }
}
