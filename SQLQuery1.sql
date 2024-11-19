-- Insert into Driver table
INSERT INTO [dbo].[Driver] (DriverName, Email, PhoneNumber, Password, VehicleInfo, LicenseNumber, Rating, Points)
VALUES
('John Doe', 'john.doe@example.com', '1234567890', 'password123', 'Toyota Prius - Blue', 'L123456789', 4.5, 120),
('Jane Smith', 'jane.smith@example.com', '0987654321', 'securepwd456', 'Honda Accord - White', 'L987654321', 4.8, 150);

-- Insert into Passenger table
INSERT INTO [dbo].[Passenger] (PassengerName, Email, PhoneNumber, Password)
VALUES
('Alice Johnson', 'alice.j@example.com', '5551234567', 'passalice1'),
('Bob Brown', 'bob.b@example.com', '5559876543', 'passbob2');

-- Insert into Booking table
INSERT INTO [dbo].[Booking] (BookingId, DriverId, PassengerId, PickupLocation, DropoffLocation)
VALUES
(1, 1, 1, '123 Elm Street', '456 Oak Avenue'),
(2, 2, 2, '789 Maple Road', '321 Pine Lane');


