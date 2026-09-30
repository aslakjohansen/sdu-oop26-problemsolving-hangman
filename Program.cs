// data

string secret = "execution";

// helpers

string? receive_guess () {
  Console.WriteLine("Place your guess: ");
  return Console.ReadLine();
}

// main

bool done = false;

while (!done) {
  // get input
  string? guess = receive_guess();
  
  // check input
  if (guess == null) continue;
  if (guess.Length != 1) continue;
  char c = Char.ToLower(guess[0]);
  if (!(c>='a' && c<='z')) continue;
  
  // check outcome
  done = true;
}

