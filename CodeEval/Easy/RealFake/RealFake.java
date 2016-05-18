package Easy.RealFake;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

/**
 * Real Fake Challenge
 * Difficulty: Easy
 * Description: Evaluate Credit Card Numbers
 * Problem Statement: https://www.codeeval.com/open_challenges/227/
 * @author Joshua Moody (joshimoo@hotmail.de)
 */
public class RealFake {
    public static void main (String[] args) throws IOException {
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;
        while((line = buffer.readLine()) != null) {
            line = line.trim();
            boolean odd = true;
            int sumOdd = 0;
            int sumEven = 0;

            for(int i = 0; i < line.length(); i++)  {
                char c = line.charAt(i);
                if(Character.isDigit(c)) {
                    if(odd) { sumOdd += c - '0'; }
                    else { sumEven += c - '0'; }
                    odd = !odd;
                }
            }

            int totalSum = sumEven + (sumOdd * 2);
            if(totalSum % 10 == 0) { System.out.println("Real"); }
            else {System.out.println("Fake"); }
        }
    }
}
