void list() {
  var names = ["Ahmet", "Mehmet", "Ali", "Buse", "Hilal"];
// Add
  names.add("Kamil");
  var newNames = ["Sevda", "Aslan", "Ceyhun"];
  names.addAll(newNames);

  // Remove
  names.remove("Kamil");
  names.removeAt(1);
  names.removeLast();
  names.removeRange(0, 3);

  // Clear
  names.clear();

  // Any
  names.any((n) => n.contains('x'));

  // Where
  var existALetter = names.where((n) => n.contains('a') || n.contains('A'));

  print(names);
  print(existALetter);
}
