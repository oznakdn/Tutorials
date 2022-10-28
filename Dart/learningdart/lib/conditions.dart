void Condition() {
// if - else
  var age = 18;
  if (age >= 18) {
    print("It can take the driver lisence");
  } else {
    print("It can not take the driver lisence");
  }

// else if
  var number = 100;
  if (number < 0) {
    print("is less than 0");
  } else if (number > 0 && number < 99) {
    print("equal and greater than 0");
  } else {
    print("equal 100");
  }

  // assert
  assert(age == 18, "It can not take the driver lisence");

  // switch - case
  switch (age) {
    case 1:
      print("Age is 1");
      break;
    case 2:
      print("Age is 2");
      break;
    default:
      print("No");
      break;
  }

  // ternary
  var result = (age > 18)
      ? print("It can take the driver lisence")
      : print("It can not take the driver lisence");
}
