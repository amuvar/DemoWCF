using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiWcfConsumeLibrary;
using ApiWcfConsumeLibrary.ServiceReference1;

using static ApiWcfConsumeLibrary.DPSSAPIService;
using System.Net.Http;

namespace DemoApplicationWCF
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            ///DPSS API calls
            var apiservice1 = new DPSSAPIService();
      

            Payload payload = new Payload
            {
                Records = new List<Record>
            {
                new Record
                {
                    BatchNo = "SG01000000000007777",
                    Time = "10:43:05",
                    Date = "2023-03-22",
                    WebOrderNo = "899899898",
                    ContactName = "Huawei",
                    AddressLine1 = "87/1 Wireless Road, 19th Floor, Capital Tower, All Seasons Place, Pathumwan",
                    AddressLine2 = "",
                    ZipCode = "10330",
                    City = "Bangkok",
                    CountryCode = "TH",
                    ContactNumber = "26370552",
                    DeliveryNumber = "777777777777",
                    NPIFlag = "Y",
                    SalesOrderNumber = "1503251814",
                    SalesDistrict = "ZZ01",
                    SoldToNumber = "CC9173",
                    ProjectCode = new List<string> { "B740RJ" },
                    Respond = "",
                    Remark = ""
                }
            }
            };

            

            var response = await apiservice1.PostAsync(payload);
            Console.WriteLine($"API Response: {response}");

            //END


            // Replace with your actual account number
            string accountNumber = "03233510";

            // Create HttpClient instance
            HttpClient httpClient = new HttpClient();
            IAusPostApiService ausPostApiService = new AusPostApiService(httpClient);

            // Example Shipment object
            // Example of creating an instance and populating data
            var shipment = new Shipment
            {
                sender_references = new List<string> { "Order 001", "SKU-1" },
                from = new Address1
                {
                    name = "Globex Toys",
                    lines = new List<string> { "241/219 Cleveland St" },
                    suburb = "Strawberry Hills",
                    state = "NSW",
                    postcode = "2012",
                    phone = "0256567567"
                },
                to = new Address1
                {
                    name = "Mandy Topshopper",
                    lines = new List<string> { "UNIT 22", "16 Sunny Street" },
                    suburb = "Yarraville",
                    state = "VIC",
                    postcode = "3013",
                    phone = "0356567567",
                    email = "mandyt@gmai.co",
                    delivery_instructions = "please leave at door"
                },
                items = new List<Item>
    {
        new Item
        {
            length = 10,
            height = 10,
            width = 10,
            weight = 2,
            packaging_type = "CTN",
            product_id = "EXP",
            authority_to_leave = true
        }
    }
            };


            try
            {
                // Call the API method
                string result = await ausPostApiService.CreateShipmentPostAsync(shipment, accountNumber);

                Console.WriteLine("Shipment creation successful:");
                Console.WriteLine(result);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error creating shipment: {ex.Message}");
            }
        }


        //            ////AustPostApi Calls

        //            var account_Number = "03233510";
        //            var apiService = new AusPostApiService(account_Number);
        //            var endpoint = "shipping/v1/labels"; // Example API endpoint
        //            try
        //            {

        //                #region "JsonData

        //                string jsonData = @"
        //{
        //    ""preferences"": [
        //        {
        //            ""type"": ""PRINT"",
        //            ""groups"": [
        //                {
        //                    ""group"": ""Parcel Post"",
        //                    ""layout"": ""THERMAL-LABEL-A6-1PP"",
        //                    ""branded"": true,
        //                    ""left_offset"": 0,
        //                    ""top_offset"": 0
        //                },
        //                {
        //                    ""group"": ""Express Post"",
        //                    ""layout"": ""THERMAL-LABEL-A6-1PP"",
        //                    ""branded"": true,
        //                    ""left_offset"": 0,
        //                    ""top_offset"": 0
        //                }
        //            ]
        //        }
        //    ],
        //    ""shipments"": [
        //        {
        //            ""shipment_id"": ""BoMK0EJs7.AAAAGQpkACDjXw""
        //        }
        //    ]
        //}";
        //                #endregion


        //                var response1 = await apiService.PostAsync(endpoint, jsonData);


        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine($"Error occurred: {ex.Message}");
        //            }
        ///End


        //WcfServiceClient client = new WcfServiceClient();


        //    ApiWcfConsumeLibrary.ServiceReference1.Address SenderDetails = new ApiWcfConsumeLibrary.ServiceReference1.Address
        //    {
        //        CompanyName = "CTDI",
        //        ContactName = "Chandan",
        //        ContactPhoneAreaCode = "123",
        //        ContactPhoneNumber = "9809809",
        //        AddressLine1 = "melbourne AU",
        //        AddressLine2 = "",
        //        Suburb = "Tullamarine",
        //        State = AustralianState.VIC,
        //        Postcode = "3043",
        //        EmailAddress = "",

        //    };
        //ApiWcfConsumeLibrary.ServiceReference1.Address CollectionDetails = new ApiWcfConsumeLibrary.ServiceReference1.Address
        //    {
        //        CompanyName = "CTDI AU",
        //        ContactName = "Rakesh",
        //        ContactPhoneAreaCode = "123",
        //        ContactPhoneNumber = "8798987",
        //        AddressLine1 = "CTDI ABC",
        //        AddressLine2 = "",
        //        Suburb = "Tullamarine",
        //        State = AustralianState.VIC,
        //        Postcode = "3043",
        //        EmailAddress = "",

        //    };
        //ApiWcfConsumeLibrary.ServiceReference1.Address ReceiverDetails = new ApiWcfConsumeLibrary.ServiceReference1.Address
        //    {
        //        CompanyName = "CTDI",
        //        ContactName = "Test name",
        //        ContactPhoneAreaCode = "211",
        //        ContactPhoneNumber = "87878788",
        //        AddressLine1 = "some addreess",
        //        AddressLine2 = "",
        //        Suburb = "Tullamarine",
        //        State = AustralianState.VIC,
        //        Postcode = "3043",
        //        EmailAddress = "",

        //    };


        //    // Create an instance of the BookingRequest and populate it with necessary data
        //    BookingRequest bookingRequest = new BookingRequest
        //    {
        //        SenderAccount = "30023444",
        //        SenderDetails = SenderDetails,
        //        CollectionDetails = CollectionDetails,
        //        ReceiverDetails = ReceiverDetails,
        //        ItemCount = 1,
        //        TotalWeight = 2,
        //        MaxLength = 2,
        //        MaxWidth = 2,
        //        MaxHeight = 2,
        //        PackagingCode = "BX",
        //        CollectionDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0),
        //        CollectionCloseTime = "1030",
        //        ServiceCode = "75",
        //        IsDangerousGoods = false,
        //        Payer = PayerType.Sender,
        //        ReceiverAccount = "",
        //        SpecialInstructions = "",
        //        CustomerReference = "",
        //        DangerousGoodsUN = "",
        //        DangerousGoodsPackingGroup = "",
        //        ConsignmentNoteNumber = ""




        //    };

        //    BookingResponse response =client.BookClientFromService(bookingRequest);

         

     //   }
    }
}
