package Easy.TrickOrTreat;

import java.io.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Trick or Treat Challenge
 * Difficulty: Easy
 * Description: Find out how much candy each child gets
 * Problem Statement: https://www.codeeval.com/open_challenges/220/
 * @author Joshua Moody (joshimoo@hotmail.de)
 */
public class TrickOrTreat {
    public static void main (String[] args) throws IOException {
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;
        while ((line = buffer.readLine()) != null) {
            line = line.trim();
            // Vampires: 3, Zombies: 4, Witches: 5 Points
            // Vampires: 1, Zombies: 1, Witches: 1, Houses: 1
            // Vampires: 3, Zombies: 2, Witches: 1, Houses: 10

            int[] actors = new int[4];
            int actorIndex = 0;

            Matcher matcher = Pattern.compile("(\\d+)").matcher(line);
            while (matcher.find()) {
                actors[actorIndex++] = Integer.parseInt(matcher.group());
            }

            int children = actors[0] + actors[1] + actors[2];
            int totalPoints = (actors[0] * 3 + actors[1] * 4 + actors[2] * 5) * actors[3];
            int pointsPerChild = totalPoints / children;
            System.out.println(pointsPerChild);
        }
    }
}
