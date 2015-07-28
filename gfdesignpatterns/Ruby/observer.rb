class Notifier
	def update(movieInfo)
		
	if movieInfo.ended 
		puts "#{movieInfo.name} in theatre number #{movieInfo.theatreNumber} ended"
	elsif movieInfo.started 
		puts "#{movieInfo.name} in theatre number #{movieInfo.theatreNumber} starts at #{movieInfo.startTime}"
	else 
		puts "#{movieInfo.name} in theatre number #{movieInfo.theatreNumber} started at #{movieInfo.startTime}"
	end
	end
end

require 'observer'

class MovieInfo
	include Observable
	attr_reader :started, :ended,:name,:theatreNumber, :startTime


	def initialize(name, theatreNumber, startTime)
	@name = name
	@theatreNumber = theatreNumber
	@startTime = startTime
	@started = false
	@ended = false
	add_observer(Notifier.new())
	add_observer(Notifier.new())
	changed
	notify_observers(self)
	end

	def start()
		@started = true
			changed
		notify_observers(self)
	end
	
	def end()
		@ended = true
		changed
		notify_observers(self)
	end
	
end

insideOutMovie = MovieInfo.new("Inside Out", 3, "8:55 PM")
wreckItRalfMovie= MovieInfo.new("Wreck It Ralf", 2, "6:15 PM")
insideOut2Movie = MovieInfo.new("Inside Out", 1,"7:20 PM")
cinderellaMovie = MovieInfo.new("Cinderella", 8, "9:30 PM")
frozenMovie = MovieInfo.new("Frozen", 5,"6:50 PM")
puts "\n"
insideOutMovie.start();
puts "\n"
wreckItRalfMovie.start();
puts "\n"
cinderellaMovie.start()
puts "\n"
insideOutMovie.end()