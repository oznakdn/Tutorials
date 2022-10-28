void loop() {
  var names = ["Ali", "Veli", "Ahmet", "Mehmet"];

  // for
  for (int i = 0; i < names.length; i++) {
    print(names[i]);
  }

  // foreach
  names.forEach((name) {
    print(name);
  });

  // for in
  for (var name in names) {
    print(name);
  }
}
