public static class DbInitializer {
  public static void Initialize(TrilloContext context) {

    // Check if any data exist.
    if (context.Hotels.Any()) {
      return;
    }

    var hotels = new Hotel[] {
      new Hotel{Name="The Venetian Macao",Gallery=["https://image-tc.galaxy.tf/wijpeg-9vualzt3dbue0hi00ba4q49ub/chatwalhotelnyc-c-004-build-crop.jpg?width=1920"],Description="This is a Hotel located in Macao",Address="Marco China",TotalVote=99, Bookings=[]},
      new Hotel{Name="The Parisian Macao",Gallery=["https://dynamic-media-cdn.tripadvisor.com/media/photo-s/01/ea/d8/2d/grand-canal-shoppes.jpg?w=600&h=-1&s=1"],Description="This is a Hotel located in China",Address="China",TotalVote=96},
      new Hotel{Name="Nina Hotel Tsuen Wan West",Gallery=["https://dynamic-media-cdn.tripadvisor.com/media/daodao/photo-s/0c/7b/d9/f2/exterior-night.jpg?w=600&h=-1&s=1"],Description="This is a Hotel located in Auckland",Address="Auckland",TotalVote=79},
      new Hotel{Name="Nina Hotel Causeway Bay",Gallery=["https://cf.bstatic.com/xdata/images/hotel/max1024x768/118479281.jpg?k=d5090d90ae7919b4637f2d7d08d0ae0df7517e4185eaebed5a5907e53cd3801d&o=&hp=1"],Description="This is a Hotel located in NZ",Address="NZ",TotalVote=39},
      new Hotel{Name="Conrad Macao",Gallery=["test1"],Description="This is a Hotel located in Beijing",Address="Beijing",TotalVote=27},
      new Hotel{Name="Legend Palace Hotel",Gallery=["test2"],Description="This is a Hotel located in Shanghai",Address="Shanghai",TotalVote=30},
      new Hotel{Name="Royal Plaza Hotel",Gallery=["test3"],Description="This is a Hotel located in Shenzhen",Address="Shenzhen",TotalVote=15},
    };
    context.Hotels.AddRange(hotels);
    context.SaveChanges();

    var reviews = new Review[] {
      new Review{UserId=101,HotelId=hotels[0].HotelId,Body="The environment is very nice.",Rating=8.8},
      new Review{UserId=102,HotelId=hotels[1].HotelId,Body="The food is very nice.",Rating=7.8},
      new Review{UserId=103,HotelId=hotels[2].HotelId,Body="The price is very nice.",Rating=6.8},
      new Review{UserId=104,HotelId=hotels[3].HotelId,Body="The bed is very nice.",Rating=3.8},
      new Review{UserId=105,HotelId=hotels[4].HotelId,Body="The location is very nice.",Rating=8.5},
      new Review{UserId=106,HotelId=hotels[5].HotelId,Body="The transport is very nice.",Rating=1.8},
      new Review{UserId=107,HotelId=hotels[6].HotelId,Body="The people is very nice.",Rating=8.2},
    };
    context.Reviews.AddRange(reviews);
    context.SaveChanges();

    var orders = new Order[] {
      new Order{UserId=101,Amount=200.3,GuestName="Ella"},
      new Order{UserId=102,Amount=229,GuestName="Hank"},
      new Order{UserId=103,Amount=93.4,GuestName="Mark"},
      new Order{UserId=104,Amount=3784.4,GuestName="Tala"},
      new Order{UserId=105,Amount=278743.4,GuestName="Ada"},
      new Order{UserId=106,Amount=3985,GuestName="Hui"},
      new Order{UserId=107,Amount=3875.6,GuestName="Kswi"},
      new Order{UserId=108,Amount=438273.5,GuestName="Edsa"},
    };
    context.Orders.AddRange(orders);
    context.SaveChanges();

    var bookings = new Booking[] {
      new Booking{HotelId=hotels[0].HotelId,OrderId=orders[0].OrderId,Price=83.3,isAvailable=true},
      new Booking{HotelId=hotels[1].HotelId,OrderId=orders[1].OrderId,Price=384.5,isAvailable=false},
      new Booking{HotelId=hotels[2].HotelId,OrderId=orders[2].OrderId,Price=22.3,isAvailable=true},
      new Booking{HotelId=hotels[3].HotelId,OrderId=orders[3].OrderId,Price=55.6,isAvailable=true},
      new Booking{HotelId=hotels[4].HotelId,OrderId=orders[4].OrderId,Price=394.5,isAvailable=false},
      new Booking{HotelId=hotels[5].HotelId,OrderId=orders[0].OrderId,Price=78,isAvailable=false},
      new Booking{HotelId=hotels[6].HotelId,OrderId=orders[6].OrderId,Price=92.4,isAvailable=true},
      new Booking{HotelId=hotels[2].HotelId,OrderId=orders[2].OrderId,Price=100,isAvailable=false},
    };
    context.Bookings.AddRange(bookings);
    context.SaveChanges();
  }
}