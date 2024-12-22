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
      new Review{UserId=101,Hotel=hotels[0], Body="The environment is very nice.",Rating=8.8},
      new Review{UserId=102,Hotel=hotels[1],Body="The food is very nice.",Rating=7.8},
      new Review{UserId=103,Hotel=hotels[2],Body="The price is very nice.",Rating=6.8},
      new Review{UserId=104,Hotel=hotels[3],Body="The bed is very nice.",Rating=3.8},
      new Review{UserId=105,Hotel=hotels[4],Body="The location is very nice.",Rating=8.5},
      new Review{UserId=106,Hotel=hotels[5],Body="The transport is very nice.",Rating=1.8},
      new Review{UserId=107,Hotel=hotels[6],Body="The people is very nice.",Rating=8.2},
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
      new Order{UserId=107,Amount=3875.6,GuestName="Kswi"}
    };

    context.Orders.AddRange(orders);
    context.SaveChanges();


    Random random = new Random();
    DateTime currentDate = DateTime.Now;
    DateTime firstDayOfNextMonth = new DateTime(currentDate.Year, currentDate.Month, 1).AddMonths(1);// Get next months date
    int numberOfBookingsPerHotel = DateTime.DaysInMonth(firstDayOfNextMonth.Year, firstDayOfNextMonth.Month); // Get next months days
    int totalHotels = hotels.Length; // Assuming hotels is already defined

    // Initialize a list to store the bookings
    List<Booking> bookingsList = new List<Booking>();

    // Generate bookings for each hotel
    for (int i = 0; i < totalHotels; i++)
    {
        for (int j = 0; j < numberOfBookingsPerHotel; j++)
        {
            // Generate a random price, for example between 50 and 500
            double randomPrice = Math.Round(random.NextDouble() * (500 - 50) + 50);

            // Get the date for each day of the next month
            DateTime bookingDate = firstDayOfNextMonth.AddDays(j).Date; 

            // Create a new booking and add it to the list
            bookingsList.Add(new Booking
            {
                Hotel = hotels[i], // Assign the current hotel
                Order = null, // Set the order ID to null
                Date = bookingDate,
                Price = randomPrice, // Assign the randomly generated price
                isAvailable = true // Set availability to true
            });
        }
    }

    // Convert the list to an array if needed
    var bookings = bookingsList.ToArray();

    context.Bookings.AddRange(bookings);
    context.SaveChanges();
  }
}