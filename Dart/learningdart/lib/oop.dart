// Class
class Car {
  String? Brand;
  String? Model;
  int? Speed;

  void GetCarInfo() {
    print("Brand: $Brand , Model: $Model , Speed: $Speed");
  }
}

class Vehicle {
  String? Type;
  String? Color;

  Vehicle(String type, String color) {
    Type = type;
    Color = color;
  }
}

// Encapsulation

class Student {
  String? _name;
  int? _age;

  getName() => _name;
  setName(String name) {
    _name = name;
  }

  getAge() => _age;
  setAge(int age) {
    _age = age;
  }
}

// Inheritance
class BaseClass {
  int? Id;

  BaseClass(int id) {
    Id = id;
  }
}

class ChildClass extends BaseClass {
  String? Name;
  ChildClass(String name, int id) : super(id) {
    Name = name;
    Id = id;
  }
}

// Polymorphism
class Employee{
  void salary(){
    print("Employee salary is \$1000.");
  }
}

class Manager extends Employee{
  @override
  void salary(){
    print("Manager salary is \$2000.");
  }
}

class Developer extends Employee{
  @override
  void salary(){
    print("Developer salary is \$3000.");
  }
}


