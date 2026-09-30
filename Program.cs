// data

string secret = "execution";
int remaining_lives = 10;
bool[] guesses = new bool['z'-'a']; // false -> not guessed

// helpers

string? receive_guess () {
  Console.WriteLine("Place your guess: ");
  return Console.ReadLine();
}

int c2int (char c) {
  return (int) (Char.ToLower(c)-'a');
}

char int2c (int i) {
  return (char)(i+'a');
}

void print_out_status () {
  // secret
  Console.WriteLine("Secret: ");
  foreach (char c in secret) {
    if (guesses[c2int(c)]) {
      Console.Write(c);
    } else {
      Console.Write("*");
    }
  }
  Console.WriteLine("");
  
  // guesses
  Console.Write("Guesses: ");
  for (int i=0 ; i<guesses.Length ; i++) {
    char c = int2c(i);
    if (guesses[i]) Console.Write(c+" ");
  }
  Console.WriteLine("");
  
  // remaining lives
  Console.WriteLine("Lives: "+remaining_lives);
  Console.WriteLine("");
}

bool contains (char input) {
  foreach (char c in secret) {
    if (input == c) {
      return true;
    }
  }
  
  return false;
}

bool finished () {
  foreach (char c in secret) {
    if (!guesses[c2int(c)]) {
      return false;
    }
  }
  
  return true;
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
  if (!contains(c)) {
    remaining_lives--;
    if (remaining_lives==0) {
      Console.WriteLine("Oops!");
      break;
    }
  }
  guesses[c2int(c)] = true;
  
  // check outcome
  if (finished()) {
    Console.WriteLine("Yay!");
    done = true;
  }
  
  // print out status
  print_out_status();
}

