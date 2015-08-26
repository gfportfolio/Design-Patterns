class Player
	attr_reader :name, :good
	
	def initalize(name, life, strength, good)
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
	puts "#{@name} -- Power: #{power}  -  Good?: #{@good}\n"
	end
	
end

class PlayerFactory
	def initalize()
	@players = {}
	end
	
	def createPlayers(name, life, strength, good)
		if @players.has_key?(name, life, strength, good)
		
			player =  @player[name, life, strength, good]
		else	
			player =  player.new(name, life, strength, good)
			players<<player
		end
		 player.to_s
	end
	
	def numberOfCreatedPlayers()
		@player.length
	end
	
end

class ArmyMaker
	def initalize()
	puts  number
		@player_factory = PlayerFactory.new()	
		@numberOfPlayers =0;


		
	end
		
	#def make(numOfPlayers)
#		@possiblePlayers= Array.new
#		@possiblePlayers<<["Woody",5, 20, true]
#		@possiblePlayers<<["Marida",12, 20, true]
#		@possiblePlayers<<["Dash",8, 20, true]
#		@possiblePlayers<<["Lightning",10, 20, true]
#		@possiblePlayers<<["Sully",15, 20, true]
#		@possiblePlayers<<["Hamm",3,20, false]
#		@possiblePlayers<<["Witch",11,20, false]
#		@possiblePlayers<<["Syndrome",10,20, false]
#		@possiblePlayers<<["Chick",13,20, false]
#		@possiblePlayers<<["Randell",8,20, false]
#		
#		rand = Random.new
#		
#		0.upto(numOfPlayers) do |x|
#		puts @numberOfPlayers 
#			@numberOfPlayers +=1
#			ranPossiblePlayerNumber = rand(@possiblePlayers.length)
#			puts ranPossiblePlayerNumber
#			puts @possiblePlayers[ranPossiblePlayerNumber][0]
#			puts @possiblePlayers[ranPossiblePlayerNumber][1]
#			puts @possiblePlayers[ranPossiblePlayerNumber][2]
#			puts @possiblePlayers[ranPossiblePlayerNumber][3]
#			
#			@player_factory.createPlayers(@possiblePlayers[ranPossiblePlayerNumber][0], @possiblePlayers[ranPossiblePlayerNumber][1],@possiblePlayers[ranPossiblePlayerNumber][2],@possiblePlayer[ranPossiblePlayerNumber][3])
#		end
#		
#				puts "Made #{@numOfPlayers}\n created #{@player_factory.numberOfCreatedPlayers} unique players"
#	end
end

army = ArmyMaker.new(100)
#army.make(100)
