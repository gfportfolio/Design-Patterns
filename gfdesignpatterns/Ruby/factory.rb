class Show
require 'date'
	def initialize()

		rand = Random.new()
		randomNum = rand.rand(20)
		@year = randomNum + 2015
		
		end
	
	def to_s
		"Name is: #{@name} Year is: #{@year} Type is: #{@type}"
	end
	
	def buildname()
		raise NotImplementedError, "#{self.class.type} does not implement buildName()"
	end
	
	
end

class Movie < Show
	def initialize()
		super
		@type = "Movie"
		@movieNames = ["Toy", "Story", "A", "Bug's", "Life", "2", "Monsters", "Inc.", "Finding", "Nemo", "The", "Incredibles", "Cars", "Ratatouille", "WALL-E", "Up", "3", "Brave", "University", "Inside", "Out"]

		rand = Random.new()
		repeatTimes = rand.rand(5)
		arraySize = @movieNames.length
		randomName = ""
		while repeatTimes>0
			repeatTimes=repeatTimes-1
			randomLocation = rand.rand(arraySize)
			randomName+=@movieNames[randomLocation]+" "
		end
		@name = randomName
	
	end
	
end
	
class Short < Show
	def initialize()
		super
		@type = "Short"
		@shortNames = ["The", "Adventures", "of", "Andre", "and", "Wally", "Luxo", "Jr", "Reds", "Dream", "Tin", "Toy", "Knick", "Knack", "Geris", "Game", "For", "Birds", "Boundin", "One", "Man", "Band", "Lifted", "Presto", "Partly", "Cloudy", "Day", "and", "Night", "La", "Luna", "Blue", "Umbrella", "Lava", "Sanjays", "Super", "Team", "Mike's", "New", "Car", "JackJack", "Attack", "Mater", "Ghostlight", "Your", "Friend", "Rat", "BURNE", "Dugs", "Special", "Mission", "George", "AJ", "Legend", "Mordu", "Party", "Central"]

		rand = Random.new()
		repeatTimes = rand.rand(5)
		arraySize = @shortNames.length
		randomName = ""
		while repeatTimes>0
			repeatTimes=repeatTimes-1
			randomLocation = rand.rand(arraySize)
			randomName+=@shortNames[randomLocation]+" "
		end
		@name = randomName
	
	end
	
end


class ShowFactory
	def initialize()
	end
	def create(type)
		case type	
			when 1
				return Short.new()
			else
				return Movie.new()
		end
	end
end

puts "Show 1"
factory = ShowFactory.new()
show1 = factory.create(1)
puts show1.to_s
puts "\nShow 2"	
show2 = factory.create(1)
puts show2.to_s
puts "\nShow 3"
show3 = factory.create(0)
puts show3.to_s
puts "\nShow 4"
show4 = factory.create(0)
puts show4.to_s	
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		