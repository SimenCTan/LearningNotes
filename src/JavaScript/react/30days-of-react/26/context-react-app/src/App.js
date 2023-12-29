// import logo from './logo.svg';
import Section from './Section';
import Heading from './Heading'
import './App.css';

function AllPosts() {
  return (
    <Section>
      <Heading>Posts</Heading>
      <RecentPosts />
    </Section>
  );
}

function RecentPosts() {
  return (
    <Section>
      <Heading>Recent Posts</Heading>
      <Post title="Flavors of Lisbon" body="...those pastéis de nata!" />
      <Post title="Buenos Aires in the rhythm of tango" body="I loved it!" />
    </Section>
  );
}

function Post({ title, body }) {
  return (
    <Section isFancy={true}>
      <Heading>{title}</Heading>
      <p>
        <i>{body}</i>
      </p>
    </Section>
  );
}

function App() {
  return (
    <div className="App">
      <Section>
        <Heading>My Profile</Heading>
        <Post title="Hello traveller!" body="Read about my adventures." />
        <AllPosts />
      </Section>
    </div>
  );
}

export default App;
