namespace AirlineManagementWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airlines",
                c => new
                    {
                        AirlineId = c.Int(nullable: false, identity: true),
                        AirlineCode = c.String(),
                        AirlineLogo = c.Binary(),
                        AirlineName = c.String(),
                        AirlineCountry = c.String(),
                    })
                .PrimaryKey(t => t.AirlineId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        FlightName = c.String(),
                        AirlineId = c.Int(nullable: false),
                        TheFlightRoute_FlightRouteId = c.Int(),
                    })
                .PrimaryKey(t => t.FlightId)
                .ForeignKey("dbo.FlightRoutes", t => t.TheFlightRoute_FlightRouteId)
                .ForeignKey("dbo.Airlines", t => t.AirlineId, cascadeDelete: true)
                .Index(t => t.AirlineId)
                .Index(t => t.TheFlightRoute_FlightRouteId);
            
            CreateTable(
                "dbo.FlightCapacities",
                c => new
                    {
                        FlightCapacityId = c.Int(nullable: false, identity: true),
                        Seats = c.Int(nullable: false),
                        TheFlightClass_FlightClassId = c.Int(),
                        Flight_FlightId = c.Int(),
                    })
                .PrimaryKey(t => t.FlightCapacityId)
                .ForeignKey("dbo.FlightClasses", t => t.TheFlightClass_FlightClassId)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightId)
                .Index(t => t.TheFlightClass_FlightClassId)
                .Index(t => t.Flight_FlightId);
            
            CreateTable(
                "dbo.FlightClasses",
                c => new
                    {
                        FlightClassId = c.Int(nullable: false, identity: true),
                        FlightClassType = c.String(),
                        TheFlightCost_FlightCostId = c.Int(),
                    })
                .PrimaryKey(t => t.FlightClassId)
                .ForeignKey("dbo.FlightCosts", t => t.TheFlightCost_FlightCostId)
                .Index(t => t.TheFlightCost_FlightCostId);
            
            CreateTable(
                "dbo.FlightCosts",
                c => new
                    {
                        FlightCostId = c.Int(nullable: false, identity: true),
                        CostPerSet = c.Double(nullable: false),
                        CurrencyCode = c.String(),
                        FlightClassId = c.Int(nullable: false),
                        TheFlightRoute_FlightRouteId = c.Int(),
                    })
                .PrimaryKey(t => t.FlightCostId)
                .ForeignKey("dbo.FlightRoutes", t => t.TheFlightRoute_FlightRouteId)
                .Index(t => t.TheFlightRoute_FlightRouteId);
            
            CreateTable(
                "dbo.FlightRoutes",
                c => new
                    {
                        FlightRouteId = c.Int(nullable: false, identity: true),
                        ArrivalTime = c.DateTime(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                        FlightDurationInMins = c.Double(nullable: false),
                        FlightId = c.Int(nullable: false),
                        RouteId = c.Int(nullable: false),
                        FlightScheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightRouteId)
                .ForeignKey("dbo.FlightSchedules", t => t.FlightScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId)
                .Index(t => t.FlightScheduleId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CityCode = c.String(),
                        TheCountry_CountryId = c.Int(),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.TheCountry_CountryId)
                .Index(t => t.TheCountry_CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.FlightSchedules",
                c => new
                    {
                        FlightScheduleId = c.Int(nullable: false, identity: true),
                        FlightDepartureDate = c.DateTime(nullable: false),
                        FlightArrivalDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FlightScheduleId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        DistanceInKms = c.Double(nullable: false),
                        FromCity_CityId = c.Int(),
                        ToCity_CityId = c.Int(),
                    })
                .PrimaryKey(t => t.RouteId)
                .ForeignKey("dbo.Cities", t => t.FromCity_CityId)
                .ForeignKey("dbo.Cities", t => t.ToCity_CityId)
                .Index(t => t.FromCity_CityId)
                .Index(t => t.ToCity_CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "ToCity_CityId", "dbo.Cities");
            DropForeignKey("dbo.FlightRoutes", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Routes", "FromCity_CityId", "dbo.Cities");
            DropForeignKey("dbo.FlightRoutes", "FlightScheduleId", "dbo.FlightSchedules");
            DropForeignKey("dbo.Cities", "TheCountry_CountryId", "dbo.Countries");
            DropForeignKey("dbo.Flights", "AirlineId", "dbo.Airlines");
            DropForeignKey("dbo.Flights", "TheFlightRoute_FlightRouteId", "dbo.FlightRoutes");
            DropForeignKey("dbo.FlightCapacities", "Flight_FlightId", "dbo.Flights");
            DropForeignKey("dbo.FlightCapacities", "TheFlightClass_FlightClassId", "dbo.FlightClasses");
            DropForeignKey("dbo.FlightClasses", "TheFlightCost_FlightCostId", "dbo.FlightCosts");
            DropForeignKey("dbo.FlightCosts", "TheFlightRoute_FlightRouteId", "dbo.FlightRoutes");
            DropIndex("dbo.Routes", new[] { "ToCity_CityId" });
            DropIndex("dbo.Routes", new[] { "FromCity_CityId" });
            DropIndex("dbo.Cities", new[] { "TheCountry_CountryId" });
            DropIndex("dbo.FlightRoutes", new[] { "FlightScheduleId" });
            DropIndex("dbo.FlightRoutes", new[] { "RouteId" });
            DropIndex("dbo.FlightCosts", new[] { "TheFlightRoute_FlightRouteId" });
            DropIndex("dbo.FlightClasses", new[] { "TheFlightCost_FlightCostId" });
            DropIndex("dbo.FlightCapacities", new[] { "Flight_FlightId" });
            DropIndex("dbo.FlightCapacities", new[] { "TheFlightClass_FlightClassId" });
            DropIndex("dbo.Flights", new[] { "TheFlightRoute_FlightRouteId" });
            DropIndex("dbo.Flights", new[] { "AirlineId" });
            DropTable("dbo.Routes");
            DropTable("dbo.FlightSchedules");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.FlightRoutes");
            DropTable("dbo.FlightCosts");
            DropTable("dbo.FlightClasses");
            DropTable("dbo.FlightCapacities");
            DropTable("dbo.Flights");
            DropTable("dbo.Airlines");
        }
    }
}
