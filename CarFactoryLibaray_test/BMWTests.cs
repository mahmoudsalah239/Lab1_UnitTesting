using CarFactoryLibrary;

namespace CarFactoryLibaray_test
{
    public class BMWTests
    {

        [Fact]
        public void IsStopped_velocity0_true()
        {

            BMW bmw = new BMW();
            bmw.velocity = 0;
            bool result = bmw.IsStopped();
            Assert.True(result);
        }
        [Fact]
        public void IncreaseVelocity_valocity15Add20_35()
        {

            BMW bmw = new BMW();
            bmw.velocity = 15;
            double AddedVelocitoy = 20;

            bmw.IncreaseVelocity(AddedVelocitoy);

            // Numeric Asserts

            Assert.InRange(bmw.velocity, 20, 35);
            Assert.NotInRange(bmw.velocity, 10, 20);
        }

        [Fact]
        public void GetDirection_DirectionForward_Backward()
        {
            // Arrange
            BMW bmw = new BMW();
            bmw.drivingMode = DrivingMode.Backward;

            // Act
            string result = bmw.GetDirection();

            // string Asserts
            Assert.Equal(DrivingMode.Backward.ToString(), result);

            Assert.StartsWith("B", result);
            Assert.EndsWith("rd", result);

            Assert.Contains("wa", result);
            Assert.DoesNotContain("zx", result);


        }


        [Fact]
        public void GetMyCar_callFunction_SameCar()
        {
            // Arrange
            BMW bmw = new BMW();
            BMW bmw2 = new BMW();

            // Act
            Car car = bmw.GetMyCar();

            // Refrence Assert
            Assert.Same(bmw, car);

        }
        [Fact]
        public void NewCar_CarTypeBMW_BMW()
        {


            // Act
            Car? car = CarFactory.NewCar(CarTypes.BMW);



            // Type Asserts
            Assert.IsType<BMW>(car);
            Assert.IsAssignableFrom<Car>(new BMW());

        }

        [Fact]
        public void NewCar_CarTypeHonda_Exception()
        {
            // Arrange



            // Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                Car? result = CarFactory.NewCar(CarTypes.Honda);
            });
        }
    }
}
