CREATE TABLE Cars (
    carId INT PRIMARY KEY IDENTITY(1,1),
    brand NVARCHAR(MAX),
    model NVARCHAR(MAX),
    year INT,
    fuelTypeId INT,
    bodyTypeId INT,
    colorId INT,
    imageLink NVARCHAR(MAX),
    FOREIGN KEY (fuelTypeId) REFERENCES FuelTypes(fuelTypeId),
    FOREIGN KEY (bodyTypeId) REFERENCES BodyTypes(bodyTypeId),
    FOREIGN KEY (colorId) REFERENCES Colors(colorId)
);


CREATE TABLE Users (
    userId INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(MAX),
    password NVARCHAR(MAX),
    email NVARCHAR(MAX)
);

CREATE TABLE ProductList (
    productId INT PRIMARY KEY IDENTITY(1,1),
    carId INT,
    sellerId INT,
    price DECIMAL(10, 2),
    quantity INT,
    FOREIGN KEY (carId) REFERENCES Cars(carId),
    FOREIGN KEY (sellerId) REFERENCES Sellers(sellerId)
);


CREATE TABLE ManufacturingCountries (
    countryId INT PRIMARY KEY IDENTITY(1,1),
    countryName NVARCHAR(MAX)
);

CREATE TABLE FuelTypes (
    fuelTypeId INT PRIMARY KEY IDENTITY(1,1),
    fuelType NVARCHAR(MAX)
);

CREATE TABLE BodyTypes (
    bodyTypeId INT PRIMARY KEY IDENTITY(1,1),
    bodyType NVARCHAR(MAX)
);

CREATE TABLE Colors (
    colorId INT PRIMARY KEY IDENTITY(1,1),
    colorName NVARCHAR(MAX)
);

CREATE TABLE Sellers (
    sellerId INT PRIMARY KEY IDENTITY(1,1),
    userId INT,
    companyName NVARCHAR(MAX),
    contactNumber NVARCHAR(MAX),
    countryId INT,
    rating DECIMAL(3, 2),
    FOREIGN KEY (userId) REFERENCES Users(userId),
    FOREIGN KEY (countryId) REFERENCES ManufacturingCountries(countryId)
);
