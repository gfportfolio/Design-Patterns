class Player
	
	def initialize(name, life, strength, good)
		@name = name
		@life = life	
	    @strength = strength
	    @good = good
	    @alive = true
	end
	
 	def power
		@strength * @life
	end
	
	def to_s()
	puts " Power: #{power}\tGood?: #{@good} \tName: #{@name} \n"
	end
	
end

class PlayerFactory
	def initialize()
	@players = {}
	@playersCounter = {}
	end
	
	def createPlayers(name, life, strength, good)
		if @players.has_key?(name)
		
			player =  @players[name]
			@playersCounter[name] = @playersCounter[name]+1
		else	
			player =  Player.new(name, life, strength, good)
			@players[name]= player
			@playersCounter[name] =1
		end
		 player.to_s
	end
	
	def numberOfCreatedPlayers()
		@players.length
	end
	
	def getHowManyTimes(name)
		@playersCounter[name]
	end
end

class ArmyMaker
	def initialize()
		@player_factory = PlayerFactory.new	
		@numberOfPlayers =0;
		@possiblePlayers= Array.new		
	end
		
	def make(numOfPlayers)
		@possiblePlayers<<["Woody",5, 20, true]
		@possiblePlayers<<["Marida",12, 20, true]
		@possiblePlayers<<["Dash",8, 20, true]
		@possiblePlayers<<["Lightning",10, 20, true]
		@possiblePlayers<<["Sully",15, 20, true]
		@possiblePlayers<<["Hamm",3,20, false]
		@possiblePlayers<<["Witch",11,20, false]
		@possiblePlayers<<["Syndrome",10,20, false]
		@possiblePlayers<<["Chick",13,20, false]
		@possiblePlayers<<["Randell",8,20, false]
		
		rand = Random.new

		0.upto(numOfPlayers-1) do |x|
			@numberOfPlayers +=1
			ranPossiblePlayerNumber = rand(@possiblePlayers.length)
			
			@player_factory.createPlayers(*@possiblePlayers[ranPossiblePlayerNumber])
		end
		
	puts "\nMade #{@numberOfPlayers} players, created #{@player_factory.numberOfCreatedPlayers} unique players\n"
	puts "\nHere is your army\n\n"
	puts "Woody Count: #{@player_factory.getHowManyTimes("Woody")}"
	puts "Marida Count: #{@player_factory.getHowManyTimes("Marida")}"
	puts "Dash Count: #{@player_factory.getHowManyTimes("Dash")}"
	puts "Lightning Count: #{@player_factory.getHowManyTimes("Lightning")}"
	puts "Sully Count: #{@player_factory.getHowManyTimes("Sully")}"
	puts "\nHere is your enemys army\n\n"
	puts "Hamm Count: #{@player_factory.getHowManyTimes("Hamm")}"
	puts "Witch Count: #{@player_factory.getHowManyTimes("Witch")}"
	puts "Syndrome Count: #{@player_factory.getHowManyTimes("Syndrome")}"
	puts "Chick Count: #{@player_factory.getHowManyTimes("Chick")}"
	puts "Randell Count: #{@player_factory.getHowManyTimes("Randell")}"
	end
end

army = ArmyMaker.new()
puts "How many players do you want"
numOfPlayers = gets.chomp.to_i
army.make(numOfPlayers)
