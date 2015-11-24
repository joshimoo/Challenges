package Easy.BlackCard;

import java.io.*;
import java.util.*;

/**
 * Black Card Challenge
 * Difficulty: Easy
 * Description: Find out who survives the game
 * Problem Statement: https://www.codeeval.com/open_challenges/222/
 * @author Joshua Moody (joshimoo@hotmail.de)
 */
public final class BlackCard {

    public static void main (String[] args) throws IOException {
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;
        while ((line = buffer.readLine()) != null) {
            line = line.trim();

            // Data layout
            // John Sara Tom Susan | 3
            // John Tom Mary | 5
            String[] split = line.split("\\|");
            int kill = Integer.parseInt(split[1].trim());
            List<String> players = new ArrayList<String>(Arrays.asList(split[0].trim().split(" ")));

            // kill people till one is left
            // reduce target by 1 since we count from 0 to target instead of 1 to target
            while(players.size() > 1) {
                players.remove((kill - 1) % players.size());
            }

            System.out.println(players.get(0));
        }
    }
}
