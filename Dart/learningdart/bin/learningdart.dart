import 'package:learningdart/conditions.dart';
import 'package:learningdart/dataTypes.dart';
import 'package:learningdart/functions.dart';
import 'package:learningdart/lists.dart';
import 'package:learningdart/loops.dart';
import 'package:learningdart/oop.dart';

void main(List<String> arguments) {
  list();
  dataType();
  Condition();
  loop();

  // functions
  Write("Ozan");
  print(Sum(10, 20));
  print(writeName("Ali"));

  // class
  Car car = Car();
  car.Brand = "Renault";
  car.Model = "Toros";
  car.Speed = 180;
  car.GetCarInfo();

  Vehicle vehicle = Vehicle("Car", "Red");
  print(vehicle.Type);

  // Encapsulation
  Student student = Student();
  student.setAge(10);
  print(student.getAge());

  // Inheritance
  ChildClass child = ChildClass("Ali", 11);
  print(child.Name);

  // Polymorphism
  Manager manager = Manager();
  manager.salary();
}
