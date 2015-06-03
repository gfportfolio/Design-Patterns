require 'singleton'

class Show
	def initialize(name, year)
		@name = name
		@year = year
	end
	
	def to_s
		"Name: #{@name}  Year: #{@year}"
	end
	
end

class  Singelton

	include Singleton

	def initialize()
		@movies = Array.new
		@shorts = Array.new
		movie1= Show.new("Toy Story",1995)
		movie2 =Show.new("Bugs Life", 1998)
		short1 = Show.new("Luxo Jr.",1986)
		short2 = Show.new("The Blue Umbrella", 2013)
		@movies<<movie1
		@movies<<movie2
		@shorts<<short1
		@shorts<<short2
	end
		
	def to_s	
	puts "Movies"
	puts @movies
	puts "\nShorts"	
	puts @shorts
	end
	
	def addMovie(name, year)
		@movies<<Show.new(name,year)
	end
	
	def addShort(name, year)
		@shorts<<Show.new(name,year)
	end
end

singleton1 = Singelton.instance
puts "SINGLETON1"
puts singleton1.to_s

singleton1.addMovie("Cars", 2006)
puts "SINGLETON1"
puts singleton1.to_s

singleton2 = Singelton.instance
puts "SINGLETON2"
puts singleton2.to_s

singleton2.addShort("For The Birds", 2006)
puts "SINGLETON2"
puts singleton2.to_s

puts "SINGLETON1"
puts singleton1.to_s

