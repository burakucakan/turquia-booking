using System;

namespace HOTOMOTO.BUS.Enumerations {

    public enum UploadType
    {
        Hotel = 1,
        Room = 2,
        Tour = 3
    }


    public enum ReservationTypes {
        Hotel = 1,
        Tour = 2,
        Transfer = 4
    }

    public enum ErrorMessageTypes {
        AsyncPostBack = 1,
        Access = 2
    }

    public enum CustomerTypes {
        Agency = 1,
        TourOperator = 2,
        EndUser = 3
    }

    public enum PropertyTypes {
        Hotel,
        Room
    }

    public enum CurrencyTypes {
        USD = 1,
        EUR = 2
    }

    public enum TransferOptions {
        VIP = 1,
        Guide = 2
    }

    public enum TransferTypes {
        Regular = 0,
        Private = 1
    }

    public enum TransferDirections {
        Arrival = 0,
        Departure = 1,
        Both = 2
    } 

    public enum NewRequestable {
        False = 0,
        Available = 1,
        OnRequest = 2,
        Confirmed = 3
    }

    public enum TourTypes {
        Circuits = 0,
        Excursion = 1
    }

    public enum QueryStrings {
        DetailSearch = 2,
        All = 3,
        Favorites = 4,
    }

    public enum GuestType {
        Adult = 0,
        Child = 1
    }

    public enum SaveMode {
        Insert = 0,
        Update = 1
    }

    public enum RoleType {
        B2B = 2,
        Admin = 1
    }

    public enum PaymentTypes {
        MoneyOrder = 1,
        CreditCard = 2,
        Credibility = 5,
        Unpaid = 6
    }

    public enum PosStatus {
        Rejected = 0,
        Approved = 1,
        Used = 2,
        YKBConnSuccess = 100,
        ConnFailure = 404,
    }

    public enum BookingStates {
        Pending = 1,
        PaymentReceived = 2,
        Provisional = 3,
        Cancelled = 4,
        Unpaid = 5
    }

    public enum SummaryType {
        NewReservation = 0,
        OldReservation = 1
    }

    public enum RoomBedPreferences { 
        NoBed = 6
    }

    public enum RecommendationType
    {
        Hotel = 0,
        Tour = 1
    }

}
